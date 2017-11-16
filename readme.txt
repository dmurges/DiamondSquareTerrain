
TERRAIN CREATION USING THE DIAMOND-SQUARE ALGORITHM


Open the main folder in Unity3d and press play to run the program.

Use the W key to move forward, the S key to move backwards, the A or D keys to move sideways.

The Q and E keys are used to roll the camera forward and backwards, respectively.

The project consists of 4 GameObjects, the Terrain, the Water, the Sun and the camera.

For the heightmap I created a Terrain gameObject, and build the heightMap on it.
The terrain object allowed me to use functions like Sampleheight and setHeights, which are built-in unity functions that allowed me to render the heightmap and track the camera's position relative to the height of the terrain.


For the TerrainScript I followed the Diamond-square Algorithm description on Wikipedia. 

For the Water I used a plane and attached a shader to it. The shader makes the plane blue and semi-transparent, therefore it appears like water.

The CameraScript is handling all the movements boundaries and rotation of the camera.

The SunRotation script rotates the Sun object around the terrain for a sunset/sunrise effect. The light of the sun comes from a built-in directional light.

I used a Unity built-in texture for the terrain as well as the water.