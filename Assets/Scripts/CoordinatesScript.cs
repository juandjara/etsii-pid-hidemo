//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Coordinates : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//}

// Draws a line in the scene view going through a point 200 pixels
// from the lower-left corner of the screen
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
	Camera camera;

	void Start()
	{
		camera = GetComponent<Camera>();
	}

	void Update()
	{
		Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
	}
}
