# PaintDropSimulation

## Overview
`PaintDropSimulation` is a C# program that simulates marbling effects between paint drops on a surface. Each paint drop is represented by a circular shape with a color, and when new drops are added to the surface, they interact with existing drops, causing their vertices to shift in a marbling pattern. 

## Features
- **Paint Drop Simulation**: Add paint drops to a surface and see them interact through a marbling effect. **Left Click** to add Paint drops, **Right click** to clear the surface.
- **Custom Input Handling**: Control the simulation using mouse inputs.
- **Dynamic Radius**: This feature allows you to change the radius of the paint drop that are being placed **Minimum** 10, **Maximum** 150, **Down Arrow Key** to increment by 10, **Up Arrow Key** to increment by 10. You are able to see your current radius in the top right.
- **Pattern Generation & Toggle**: 
  - Press **M** to start generating a pattern using paint drops.
  - Press **E** to stop and reset the generation.
  - Toggle between **Phyllotaxis** and **Spirograph** patterns by pressing **P**.

## Setup and Installation
### Clone
1. Clone the repository.
2. Install any dependancies
3. Run the program.

### Download Artifact

1. Download the artifact from the pipeline
2. Extract the files
3. Run the .exe file.

## Testing
In order to run the tests, Use an IDE or run 
```bash 
dotnet test
```
