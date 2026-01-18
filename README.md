# Virtual Environment Design - Unity Puzzle Game

A first-person puzzle and exploration project built with Unity 2018.3.7f1. Players explore an interior environment, collect and inspect items, solve keypad and door interactions, and manage a small inventory. The project also includes a Google Cardboard demo scene for VR viewing.

## Features
- First-person movement with walking, running, crouching, and head-bob/footstep audio.
- Inventory system for picking up, displaying, and using items in-world.
- Interaction prompts with contextual pickup/show behavior and distance-based hints.
- Puzzle flow that includes keypads, drawers, doors, and scene progression.
- Pause menu, win screen, and blur-driven UI state handling.
- VR/Cardboard demo content and prefabs included under the VR folder.

## Controls (default)
- Move: WASD
- Look: Mouse
- Run: Hold Left Shift
- Crouch: C
- Interact / Pick Up / Inspect: F (when prompt shows)
- Inventory: Tab (toggles inventory panel)
- Pause/Menu: Escape (resume via menu)

## Project Structure
- Scenes: Main gameplay in [Assets/Scenes/Main2.unity](Assets/Scenes/Main2.unity); additional sample lighting tests in [Assets/Scenes/SampleScene.unity](Assets/Scenes/SampleScene.unity); Cardboard demo scenes in [Assets/VR/Cardboard](Assets/VR/Cardboard).
- Scripts: Gameplay and systems in [Assets/Scripts](Assets/Scripts), including player controllers, inventory, interaction items, and game managers.
- UI: Sprites and materials under [Assets/UISprites](Assets/UISprites); UI logic in [Assets/Scripts/GameManagers](Assets/Scripts/GameManagers) and [Assets/Scripts/Player/InventorySystem](Assets/Scripts/Player/InventorySystem).
- Audio: Footstep and effect clips in [Assets/VR/FirstPersonCharacter/Audio](Assets/VR/FirstPersonCharacter/Audio).

## Requirements
- Unity 2018.3.7f1 (matching [ProjectSettings/ProjectVersion.txt](ProjectSettings/ProjectVersion.txt)).
- Git LFS installed (large textures, audio, and prefabs are tracked in LFS).

## Getting Started
1. Install Git LFS: `git lfs install`.
2. Clone the repository: `git clone https://github.com/H-M-Master/Virtual-Environment-Design_Unity-Puzzle-Game.git`.
3. Open the project folder in Unity 2018.3.7f1.
4. Open the main scene: [Assets/Scenes/Main2.unity](Assets/Scenes/Main2.unity).
5. Enter Play Mode to test the puzzle flow and interactions.

## Building
- Use `File > Build Settings` to select your target platform (Windows/Mac). Add [Assets/Scenes/Main2.unity](Assets/Scenes/Main2.unity) (and any other required scenes) to the build list, then click Build.
- If you modify lighting, rebake lightmaps before building to include updated baked data.

## VR/Cardboard
- Cardboard demo content is located in [Assets/VR/Cardboard](Assets/VR/Cardboard). Open the demo scene(s) in that folder to test the VR sample. Switch the Unity XR settings as needed for your target device.

## Troubleshooting
- If large assets are missing after clone, run `git lfs pull` inside the repo.
- If controls do not respond, ensure the Game view is focused and the UI blur/pause panels are not active.

## License
- License is not specified in this repository. Add one before distributing builds.