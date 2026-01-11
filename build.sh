#!/bin/bash

# HyperTizen Build Script
# Builds .tpk packages for Tizen 6.0+

set -e

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

# Configuration
VERSION=${1:-"1.0.0"}
TIZEN_STUDIO_PATH=${TIZEN_STUDIO_PATH:-"$HOME/tizen-studio"}
PROFILE_NAME=${PROFILE_NAME:-"HyperTizen"}
BUILD_CONFIG=${BUILD_CONFIG:-"Release"}

echo -e "${GREEN}=== HyperTizen Build Script ===${NC}"
echo -e "Version: ${YELLOW}$VERSION${NC}"
echo -e "Build Config: ${YELLOW}$BUILD_CONFIG${NC}"
echo ""

# Check if Tizen Studio is installed
if [ ! -d "$TIZEN_STUDIO_PATH" ]; then
    echo -e "${RED}Error: Tizen Studio not found at $TIZEN_STUDIO_PATH${NC}"
    echo "Please install Tizen Studio or set TIZEN_STUDIO_PATH environment variable"
    exit 1
fi

# Tizen CLI tool
TIZEN_CLI="$TIZEN_STUDIO_PATH/tools/ide/bin/tizen"

if [ ! -f "$TIZEN_CLI" ]; then
    echo -e "${RED}Error: Tizen CLI not found at $TIZEN_CLI${NC}"
    exit 1
fi

echo -e "${GREEN}Step 1: Checking dependencies...${NC}"

# Check for dotnet
if ! command -v dotnet &> /dev/null; then
    echo -e "${RED}Error: dotnet CLI not found. Please install .NET 6.0 SDK${NC}"
    exit 1
fi

echo -e "${GREEN}✓ All dependencies found${NC}"
echo ""

# Update version in manifest files
echo -e "${GREEN}Step 2: Updating version to $VERSION...${NC}"

# Update tizen-manifest.xml
sed -i.bak "s/version=\"[^\"]*\"/version=\"$VERSION\"/" HyperTizen/tizen-manifest.xml
echo -e "${GREEN}✓ Updated HyperTizen/tizen-manifest.xml${NC}"

# Update config.xml
sed -i.bak "s/version=\"[^\"]*\"/version=\"$VERSION\"/" HyperTizenUI/config.xml
echo -e "${GREEN}✓ Updated HyperTizenUI/config.xml${NC}"
echo ""

# Build .NET Service
echo -e "${GREEN}Step 3: Building HyperTizen Service (.NET)...${NC}"
cd HyperTizen

# Restore dependencies
echo "Restoring NuGet packages..."
dotnet restore HyperTizen.csproj

# Build
echo "Building project..."
dotnet build HyperTizen.csproj \
    -c $BUILD_CONFIG \
    -f tizen60 \
    /p:TizenCreateTpk=false

if [ $? -ne 0 ]; then
    echo -e "${RED}Error: .NET build failed${NC}"
    exit 1
fi

echo -e "${GREEN}✓ .NET Service built successfully${NC}"
cd ..
echo ""

# Package Service TPK
echo -e "${GREEN}Step 4: Packaging HyperTizen Service (.tpk)...${NC}"

# Check if security profile exists
if ! "$TIZEN_CLI" security-profiles list | grep -q "$PROFILE_NAME"; then
    echo -e "${YELLOW}Warning: Security profile '$PROFILE_NAME' not found${NC}"
    echo "You may need to create a security profile for signing:"
    echo "  $TIZEN_CLI certificate -a MyApp -p password -c US -s CA -ct San -o Org -n Name -e email@example.com -f filename"
    echo "  $TIZEN_CLI security-profiles add -n $PROFILE_NAME -a /path/to/author.p12 -p password"
    echo ""
    echo -e "${YELLOW}Attempting to package without explicit profile...${NC}"
fi

cd HyperTizen
"$TIZEN_CLI" package -t tpk -s "$PROFILE_NAME" -- bin/$BUILD_CONFIG/tizen60 || {
    echo -e "${YELLOW}Packaging with default profile...${NC}"
    "$TIZEN_CLI" package -t tpk -- bin/$BUILD_CONFIG/tizen60
}

if [ $? -ne 0 ]; then
    echo -e "${RED}Error: Service TPK packaging failed${NC}"
    exit 1
fi

# Find and rename TPK
SERVICE_TPK=$(find bin/$BUILD_CONFIG/tizen60 -name "*.tpk" | head -1)
if [ -n "$SERVICE_TPK" ]; then
    cp "$SERVICE_TPK" "../HyperTizen-Service-v${VERSION}.tpk"
    echo -e "${GREEN}✓ Service TPK created: HyperTizen-Service-v${VERSION}.tpk${NC}"
else
    echo -e "${RED}Error: Could not find generated TPK file${NC}"
    exit 1
fi

cd ..
echo ""

# Package Web UI
echo -e "${GREEN}Step 5: Packaging HyperTizenUI (.wgt)...${NC}"

cd HyperTizenUI
"$TIZEN_CLI" package -t wgt -s "$PROFILE_NAME" -- . || {
    echo -e "${YELLOW}Packaging with default profile...${NC}"
    "$TIZEN_CLI" package -t wgt -- .
}

if [ $? -ne 0 ]; then
    echo -e "${RED}Error: UI WGT packaging failed${NC}"
    exit 1
fi

# Find and rename WGT
UI_WGT=$(find . -name "*.wgt" -maxdepth 1 | head -1)
if [ -n "$UI_WGT" ]; then
    mv "$UI_WGT" "../HyperTizenUI-v${VERSION}.wgt"
    echo -e "${GREEN}✓ UI WGT created: HyperTizenUI-v${VERSION}.wgt${NC}"
else
    echo -e "${RED}Error: Could not find generated WGT file${NC}"
    exit 1
fi

cd ..
echo ""

# Summary
echo -e "${GREEN}=== Build Complete ===${NC}"
echo ""
echo "Generated packages:"
echo "  • HyperTizen-Service-v${VERSION}.tpk"
echo "  • HyperTizenUI-v${VERSION}.wgt"
echo ""
echo "To install on your Tizen TV:"
echo "  1. Enable Developer Mode on your TV"
echo "  2. Connect to your TV: $TIZEN_CLI connect <TV_IP>"
echo "  3. Install packages:"
echo "     $TIZEN_CLI install -n HyperTizen-Service-v${VERSION}.tpk -t <device_name>"
echo "     $TIZEN_CLI install -n HyperTizenUI-v${VERSION}.wgt -t <device_name>"
echo ""
echo -e "${GREEN}Done!${NC}"
