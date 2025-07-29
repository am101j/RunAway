# WaterRunner Game

A Unity-based endless runner game where players navigate through obstacles and repair them to score points.

## Game Overview

- **Genre**: Endless Runner
- **Platform**: Unity Game Engine
- **Objective**: Navigate through obstacles, repair them using tools, and achieve the highest score

## Features

- Player movement and controls
- Obstacle spawning system
- Interactive repair mechanics with drag-and-drop tools
- Score tracking and leaderboard system
- User authentication and database integration
- Fun facts display
- Audio and visual effects

## Game Mechanics

1. **Movement**: Player runs automatically and can move between lanes
2. **Obstacles**: Various obstacles spawn that need to be repaired
3. **Repair System**: Drag tools to target zones to fix obstacles
4. **Scoring**: Points awarded for successfully repairing obstacles
5. **Game Over**: Game ends after encountering 10 obstacles

## Project Structure

- `Assets/Scripts/` - Core game scripts
- `Assets/Prefabs/` - Game object prefabs
- `Assets/Scenes/` - Game scenes
- `Assets/Materials/` - Materials and textures
- `Assets/Sounds/` - Audio files
- `Assets/UI/` - User interface elements

## Key Scripts

- `PlayerController.cs` - Handles player movement and input
- `ObstacleSpawner.cs` - Manages obstacle generation
- `ObstacleTrigger.cs` - Handles obstacle interactions
- `ScoreManager.cs` - Tracks score and game state
- `DatabaseManager.cs` - Manages user data and leaderboards
- `ToolDrag.cs` - Implements drag-and-drop repair mechanics

## Setup

1. Open the project in Unity
2. Load the main scene
3. Configure database settings if needed
4. Build and run the game

## Controls

- Movement controls (configured in PlayerController)
- Mouse/Touch for drag-and-drop repair interactions

## Development

Built with Unity and C#. Uses SQLite for local data storage and includes user authentication system.
