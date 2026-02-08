# ARPLACER

An Augmented Reality (AR) application built with Unity for placing and visualizing virtual objects in real-world environments.

## 📋 Overview

ARPLACER is an AR application that allows users to place, manipulate, and interact with virtual 3D objects in their physical space using their mobile device's camera. This project leverages Unity's AR Foundation to provide a cross-platform AR experience.

## ✨ Features

- **Object Placement**: Place virtual objects in the real world using AR
- **Real-time Tracking**: Accurate tracking of surfaces and environment
- **Interactive Controls**: Rotate, scale, and move placed objects
- **Cross-Platform**: Works on both iOS and Android devices
- **Intuitive UI**: User-friendly interface for easy interaction

## 🛠️ Technologies Used

- **Unity** (version 2021.3 or later recommended)
- **AR Foundation** - Unity's cross-platform AR framework
- **ARCore** (Android) - Google's AR platform
- **ARKit** (iOS) - Apple's AR platform
- **C#** - Primary scripting language

## 📱 System Requirements

### Development
- Unity 2021.3 LTS or later
- Visual Studio or Visual Studio Code
- Git for version control

### Target Devices
- **Android**: Android 7.0 (API level 24) or higher with ARCore support
- **iOS**: iOS 11.0 or higher with ARKit support

## 🚀 Getting Started

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/sryn623/ARPLACER.git
   cd ARPLACER
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open" and navigate to the cloned project folder
   - Unity will automatically import all assets and regenerate the Library folder
   - This may take a few minutes on first load

3. **Install Required Packages**
   - Unity should automatically install required packages
   - If not, go to Window > Package Manager and install:
     - AR Foundation
     - ARCore XR Plugin (for Android)
     - ARKit XR Plugin (for iOS)

### Building for Mobile

#### Android Build
1. Go to File > Build Settings
2. Select "Android" platform
3. Click "Switch Platform"
4. Go to Player Settings and configure:
   - Set minimum API level to 24 or higher
   - Enable ARCore in XR Settings
5. Click "Build" or "Build and Run"

#### iOS Build
1. Go to File > Build Settings
2. Select "iOS" platform
3. Click "Switch Platform"
4. Go to Player Settings and configure:
   - Set minimum iOS version to 11.0 or higher
   - Enable ARKit in XR Settings
5. Click "Build" to generate Xcode project
6. Open the generated Xcode project and build to device

## 📖 Usage

1. **Launch the app** on your AR-capable device
2. **Point your camera** at a flat surface (floor, table, etc.)
3. **Tap to place** virtual objects in the detected area
4. **Use gestures** to interact with placed objects:
   - Single finger drag: Move object
   - Two finger pinch: Scale object
   - Two finger rotate: Rotate object
5. **Delete objects** by selecting and using the delete button

## 🗂️ Project Structure

```
ARPLACER/
├── Assets/                 # Unity assets folder
│   ├── Scenes/            # Unity scenes
│   ├── Scripts/           # C# scripts
│   ├── Prefabs/           # Reusable game objects
│   ├── Materials/         # Materials and textures
│   └── Models/            # 3D models
├── Packages/              # Unity packages configuration
├── ProjectSettings/       # Unity project settings
└── README.md             # This file
```

## 🤝 Contributing

Contributions are welcome! If you'd like to contribute to ARPLACER:

1. Fork the repository
2. Create a new branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

## 🐛 Known Issues

- Initial surface detection may take a few seconds
- Performance may vary based on device capabilities
- Some older devices may not support all AR features

## 📝 Roadmap

- [ ] Add support for multiple object types
- [ ] Implement object persistence (save placed objects)
- [ ] Add multiplayer/shared AR experiences
- [ ] Improve UI/UX design
- [ ] Add measurement tools
- [ ] Implement screenshot/video capture

## 🙏 Acknowledgments

- Unity Technologies for AR Foundation
- Google for ARCore
- Apple for ARKit
- The Unity AR community for inspiration and support
