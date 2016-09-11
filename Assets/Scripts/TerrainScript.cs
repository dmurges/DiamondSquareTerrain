using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {

	/* create Terrain, heightmap array and max size*/
	public Terrain terrain;
	public int size = 520;
	private float[,] heightMap;


	/*set target frame rate to 40*/
	void Awake() {
		Application.targetFrameRate = 40;
	}

	/*call the algorithm*/
	void Start()
	{


		/*initialize variables*/
		float cornerPoints, randValue,midPoint;
		float corners = 4.0f;
		float reducingValue = 0.5f;
		float byTwo = 2.0f;
		int EdgeLength, x, y, halfEdgeLength;

		/*2d array*/
		heightMap = new float[ size, size ];




		/*The 4 corner points are set to initial values*/
		heightMap [0, 0] = 1.0f;
		heightMap [size - 1, 0] = 1.0f;
		heightMap [0, size - 1] = 1.0f;
		heightMap [size - 1, size - 1] = 1.0f;

		/*the diamond step*/
		for (EdgeLength = size -1; EdgeLength >= 2; EdgeLength /= 2) {
			halfEdgeLength = EdgeLength / 2;

			/* receiveing diamond values*/
			for (x = 0; x < size - 1; x += EdgeLength) {
				for (y = 0; y < size - 1; y += EdgeLength) {

					/*get cornerpoints*/
					cornerPoints = heightMap [x, y];
					cornerPoints += heightMap [x + EdgeLength, y];
					cornerPoints += heightMap [x, y + EdgeLength];
					cornerPoints += heightMap [x + EdgeLength, y + EdgeLength];

					/*divide by number of corners to get the midpoint*/
					midPoint = cornerPoints / corners;

					/*add a random value to the midpoint*/
					randValue = (Random.value * byTwo * reducingValue) - reducingValue;

					/*clamp value between 0 and 1*/
					midPoint = Mathf.Clamp01 (midPoint + randValue);

					/*add value to heightmap*/
					heightMap [x + halfEdgeLength, y + halfEdgeLength] = midPoint;
				}
			}

			/*the square step*/
			for (x = 0; x < size - 1; x += halfEdgeLength) {
				for (y = (x + halfEdgeLength) % EdgeLength; y < size - 1; y += EdgeLength) {

					/*getting cornerpoints*/
					cornerPoints = heightMap [(x - halfEdgeLength + size - 1) % (size - 1), y];
					cornerPoints += heightMap [(x + halfEdgeLength) % (size - 1), y];
					cornerPoints += heightMap [x, (y + halfEdgeLength) % (size - 1)];
					cornerPoints += heightMap [x, (y - halfEdgeLength + size - 1) % (size - 1)];

					/*get the midpoint*/
					midPoint = cornerPoints / corners;


					/*add a random value to the midpoint*/
					randValue = (Random.value * byTwo * reducingValue) - reducingValue;
					/*clamp value between 0 and 1*/
					midPoint = Mathf.Clamp01 (midPoint + randValue);

					/*add value to hightmap*/
					heightMap [x, y] = midPoint;

					/*set edge value*/
					if (x == 0) {
						heightMap [size - 1, y] = midPoint;
					}

					/*set edge value*/
					if (y == 0) {
						heightMap [x, size - 1] = midPoint;
					}
				}
			}

			/*reduces the random value at each iteration*/
			reducingValue /= byTwo;
		}
			
		/*generate terrain*/
		terrain.terrainData.SetHeights( 0, 0, heightMap );

	}
		


}