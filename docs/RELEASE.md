# Guide de Release HyperTizen

Ce guide explique comment créer une release et générer des fichiers `.tpk` pour HyperTizen.

## Table des matières

- [Build Local](#build-local)
- [Release Automatique via GitHub Actions](#release-automatique-via-github-actions)
- [Installation sur TV Tizen](#installation-sur-tv-tizen)

---

## Build Local

### Prérequis

1. **Tizen Studio** installé
   - Télécharger depuis: https://developer.tizen.org/development/tizen-studio/download
   - Version recommandée: 5.5+

2. **.NET SDK 6.0+**
   - Télécharger depuis: https://dotnet.microsoft.com/download

3. **Profil de sécurité Tizen** configuré
   ```bash
   # Créer un certificat
   tizen certificate \
     -a HyperTizen \
     -p <votre_mot_de_passe> \
     -c US \
     -s CA \
     -ct San \
     -o "Votre Organisation" \
     -n "Votre Nom" \
     -e votre.email@example.com \
     -f hypertizen

   # Créer un profil de sécurité
   tizen security-profiles add \
     -n HyperTizen \
     -a ~/tizen-studio-data/keystore/author/hypertizen.p12 \
     -p <votre_mot_de_passe>

   # Définir comme profil actif
   tizen cli-config "profiles.active=HyperTizen"
   ```

### Utilisation du script de build

Le script `build.sh` automatise la création des packages `.tpk` et `.wgt`.

```bash
# Build avec version par défaut (1.0.0)
./build.sh

# Build avec version spécifique
./build.sh 2.1.0

# Build en mode Debug
BUILD_CONFIG=Debug ./build.sh 2.1.0

# Build avec Tizen Studio dans un chemin personnalisé
TIZEN_STUDIO_PATH=/custom/path/tizen-studio ./build.sh
```

### Fichiers générés

Le script génère deux fichiers:
- `HyperTizen-Service-v{VERSION}.tpk` - Service backend (.NET)
- `HyperTizenUI-v{VERSION}.wgt` - Interface web

---

## Release Automatique via GitHub Actions

### Méthode 1: Via Tag Git (Recommandée)

Cette méthode crée automatiquement une release GitHub avec les fichiers `.tpk`.

```bash
# 1. Créer et pousser un tag
git tag -a v1.0.0 -m "Release version 1.0.0"
git push origin v1.0.0

# Le workflow GitHub Actions se déclenche automatiquement
# Une release sera créée avec les fichiers .tpk et .wgt attachés
```

### Méthode 2: Déclenchement Manuel

Vous pouvez aussi déclencher le workflow manuellement depuis GitHub:

1. Aller sur **Actions** dans votre dépôt GitHub
2. Sélectionner **Build and Release TPK**
3. Cliquer sur **Run workflow**
4. Entrer la version (ex: `1.0.0`)
5. Cliquer sur **Run workflow**

Les fichiers seront disponibles dans les artifacts de l'action (pas de release GitHub dans ce cas).

### Workflow GitHub Actions

Le fichier `.github/workflows/release.yml` effectue automatiquement:

1. ✅ Installation de Tizen Studio CLI
2. ✅ Création d'un certificat de test
3. ✅ Build du service .NET (Tizen 6.0)
4. ✅ Package du service en `.tpk`
5. ✅ Package de l'UI web en `.wgt`
6. ✅ Création d'une release GitHub avec les fichiers

### Variables d'environnement

Le workflow utilise les variables suivantes (configurables dans `.github/workflows/release.yml`):

- `TIZEN_STUDIO_VERSION`: Version de Tizen Studio (défaut: `5.5`)
- `DOTNET_VERSION`: Version .NET SDK (défaut: `6.0.x`)

---

## Installation sur TV Tizen

### Activer le mode développeur

1. Sur votre TV Samsung Tizen:
   - Aller dans **Applications**
   - Saisir `12345` sur la télécommande
   - Activer **Developer mode**
   - Entrer l'IP de votre PC
   - Redémarrer la TV

### Installer via Tizen CLI

```bash
# 1. Connecter à la TV
tizen connect <IP_DE_VOTRE_TV>

# 2. Vérifier la connexion
tizen devices

# 3. Installer le service
tizen install -n HyperTizen-Service-v1.0.0.tpk -t <nom_device>

# 4. Installer l'UI
tizen install -n HyperTizenUI-v1.0.0.wgt -t <nom_device>

# 5. Lancer l'application UI
tizen run -p 6jwjAZfoVq.HyperTizenUI -t <nom_device>
```

### Installer via Tizen Studio IDE

1. Ouvrir **Tizen Studio**
2. Aller dans **Tools** > **Device Manager**
3. Ajouter votre TV (Remote Device)
4. Glisser-déposer les fichiers `.tpk` et `.wgt` sur votre device
5. Lancer l'application depuis le menu Apps de la TV

### Vérifier l'installation

```bash
# Lister les applications installées
tizen list apps -t <nom_device>

# Vérifier les logs
tizen log -t <nom_device>
```

---

## Dépannage

### Erreur: "Author certificate not found"

Vous devez créer un profil de sécurité (voir [Prérequis](#prérequis)).

### Erreur: "Tizen CLI not found"

Assurez-vous que Tizen Studio est dans votre PATH:

```bash
export PATH=$PATH:$HOME/tizen-studio/tools/ide/bin
export PATH=$PATH:$HOME/tizen-studio/tools
```

### Erreur: "dotnet build failed"

Vérifiez que vous avez .NET SDK 6.0+ installé:

```bash
dotnet --version
```

### Build réussit mais installation échoue

1. Vérifiez que la TV est en mode développeur
2. Vérifiez la connexion réseau entre votre PC et la TV
3. Essayez de recréer le certificat avec des informations différentes

### GitHub Actions échoue

1. Vérifiez les logs de l'action dans l'onglet **Actions**
2. Les erreurs courantes:
   - Timeout lors du téléchargement de Tizen Studio (réessayez)
   - Problème de certificat (normalement géré automatiquement)

---

## Versions et Compatibilité

- **Tizen 6.0+**: Compatible (version minimale)
- **Tizen 6.5+**: Compatible
- **Tizen 7.0+**: Compatible (utilise SecVideoCaptureT7)
- **Tizen 8.0+**: Compatible (utilise SecVideoCaptureT8 optimisé)

---

## Structure des fichiers

```
HyperTizen/
├── .github/
│   └── workflows/
│       └── release.yml          # Workflow GitHub Actions
├── HyperTizen/                  # Service .NET
│   ├── HyperTizen.csproj
│   └── tizen-manifest.xml
├── HyperTizenUI/                # Web UI
│   └── config.xml
├── build.sh                     # Script de build local
└── docs/
    └── RELEASE.md              # Ce fichier
```

---

## Ressources

- [Tizen .NET Documentation](https://docs.tizen.org/application/dotnet/index)
- [Tizen CLI Guide](https://docs.tizen.org/application/tizen-studio/common-tools/command-line-interface/)
- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [HyperHDR Documentation](https://github.com/awawa-dev/HyperHDR)
