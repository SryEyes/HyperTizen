# HyperTizen

### Color up your Tizen TV with HyperTizen!
HyperTizen is a Hyperion / HyperHDR capturer for Tizen TVs.

<p align="center">
    <a href="https://discord.gg/m2P7v8Y2qR">
       <picture>
           <source height="24px" media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/13122796/178032563-d4e084b7-244e-4358-af50-26bde6dd4996.png" />
           <img height="24px" src="https://user-images.githubusercontent.com/13122796/178032563-d4e084b7-244e-4358-af50-26bde6dd4996.png" />
       </picture>
       </a>
       <a href="https://www.youtube.com/@tizenbrew">
      <picture>
         <source height="24px" media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/13122796/178032714-c51c7492-0666-44ac-99c2-f003a695ab50.png" />
         <img height="24px" src="https://user-images.githubusercontent.com/13122796/178032714-c51c7492-0666-44ac-99c2-f003a695ab50.png" />
     </picture>
     </a>
</p>

# Getting Started

You can read the [guide](./docs/README.md) to get started with HyperTizen.

## Compatibility

- **Tizen 6.0+** (Samsung Smart TV 2020+)
- Tizen 7.0+
- Tizen 8.0+

## Installation

### Download Pre-built Packages

Download the latest `.tpk` and `.wgt` files from the [Releases](../../releases) page.

### Build from Source

See [Release Guide](./docs/RELEASE.md) for instructions on building `.tpk` packages locally or via GitHub Actions.

```bash
# Quick build
./build.sh 1.0.0
```

## Development

### Creating a Release

**Automatic Release (Recommended):**
```bash
git tag -a v1.0.0 -m "Release 1.0.0"
git push origin v1.0.0
```

GitHub Actions will automatically build and create a release with `.tpk` files.

**Manual Build:**
```bash
./build.sh 1.0.0
```

See the [Release Guide](./docs/RELEASE.md) for detailed instructions.