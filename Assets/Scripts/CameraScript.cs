using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float moveSpeed = 10f;
	public float turnSpeed = 10f;
	public bool invertRotation = true;

	private Transform camTransform;

	// Use this for initialization
	void Start () {

		camTransform = GetComponent<Transform>();
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

		float delta = Time.deltaTime;
		float horiz = Input.GetAxis("Horizontal");
		float vert  = Input.GetAxis("Vertical");
		float y = 0;

		if(Input.GetKey(KeyCode.Q)) {
			y = 2;
		} else if (Input.GetKey(KeyCode.E)) {
			y = -2;
		}

		camTransform.Translate(new Vector3(horiz, y, vert) * delta * moveSpeed);

		float turnY = Input.GetAxis("Mouse Y");
		if(invertRotation) {
			turnY = turnY * -1;
		}
		camTransform.Rotate(Vector3.right * delta * turnY * turnSpeed);

		float turnX = Input.GetAxis("Mouse X");
		camTransform.Rotate(Vector3.up * delta * turnX * turnSpeed, Space.World);
	}
}
