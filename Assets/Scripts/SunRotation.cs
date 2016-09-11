using UnityEngine;
using System.Collections;

public class SunRotation : MonoBehaviour {

	/*create reference and set speed of rotation*/
	public GameObject terrain;
	public float speed = 10.0f;

	void Start () {
	
	}
	
	/*call the orbiting function*/
	void Update () {

		OrbitAround ();
	}

	/*orbit around Gameobject Terrain*/
	void OrbitAround(){
		transform.RotateAround (terrain.transform.position, Vector3.right, speed * Time.deltaTime);
	}

}
