using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	/*camera movement and rotation speeds*/
	public float moveSpeed = 5.0f;
	public float rotationSpeed = 2.0f;

	/*set boundaries for camera*/
	private float terrainSizeX = 500f;
	private float terrainSizeY = 800f;
	private float terrainSizeZ = 500f;

	/*initial yaw and pitch*/
	private float yaw = 0.0f;
	private float pitch = 45.0f;

	/*set horizontal and vertical rotation speeds*/
	public float speedH = 2.0f;
	public float speedV = 2.0f;


	void Update ()
	{
		/*get the terrain height at camera's position*/
		float terrainHeight = Terrain.activeTerrain.SampleHeight (transform.position);

		/*if E and Q are not pressed, the mouse can be used for yaw and pitch*/
		if (!Input.GetKey (KeyCode.E) && !Input.GetKey (KeyCode.Q)) {
			yaw += speedH * Input.GetAxis ("Mouse X");
			pitch -= speedV * Input.GetAxis ("Mouse Y");

			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		}

		/*move forward*/
		if (Input.GetKey (KeyCode.W)) {
			
			transform.Translate (Vector3.forward * moveSpeed);
		}

		/*move backwards*/
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * moveSpeed);
		}

		/*move to the left*/
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * moveSpeed);
		}

		/*move to the right*/
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * moveSpeed);
		}

		/*roll forward*/
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (new Vector3 (rotationSpeed, 0, 0));
			pitch += rotationSpeed;
		}

		/*roll backwards*/
		if (Input.GetKey (KeyCode.E)) {
			transform.Rotate (new Vector3 (-rotationSpeed, 0, 0));
			pitch -= rotationSpeed;
		}
	
		/*set x boundaries*/
		if (transform.position.x >= terrainSizeX) {
			transform.position = new Vector3 (terrainSizeX - 10, transform.position.y, transform.position.z);
		}
		if (transform.position.x <= 0) {
			transform.position = new Vector3 (10, transform.position.y, transform.position.z);
		}

		/*set y boundaries*/
		if (transform.position.y >= terrainSizeY) {
			transform.position = new Vector3 (transform.position.x, terrainSizeY - 10, transform.position.z);
		}
		if (terrainHeight > transform.position.y) {
			transform.position = new Vector3 (transform.position.x, terrainHeight + 10, transform.position.z);
		}

		/*set z boundaries*/
		if (transform.position.z >= terrainSizeZ) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, terrainSizeZ - 10);
		}
		if (transform.position.z <= 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 10);
		}

	}


}