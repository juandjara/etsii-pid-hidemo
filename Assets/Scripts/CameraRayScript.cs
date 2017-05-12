using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayScript : MonoBehaviour {

	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)) {
				Debug.Log("HIT "+hit.point.ToString());
			}
		}
	}
}
