using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOnClickScript : MonoBehaviour {

	RaycastHit hit;
	public GameObject prefab;

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit)) {
			if(Input.GetMouseButtonDown(0)) {
				Vector3 position = Vector3.zero;

				Vector3 objectCenter = hit.transform.position;
				Vector3 fromCenterToClickPoint = hit.point - objectCenter;

				if(hit.transform.gameObject.tag == "Cube") {
					float x = (objectCenter.x); 
					float y = (objectCenter.y);
					float z = (objectCenter.z);
					
					float xDirection = Mathf.Sign(fromCenterToClickPoint.x);
					float yDirection = Mathf.Sign(fromCenterToClickPoint.y);
					float zDirection = Mathf.Sign(fromCenterToClickPoint.z);

					if(Mathf.Abs(fromCenterToClickPoint.x) >= 0.5f) {
						x += xDirection;
					}
					if(Mathf.Abs(fromCenterToClickPoint.y) >= 0.5f) {
						y += yDirection;
					}
					if(Mathf.Abs(fromCenterToClickPoint.z) >= 0.5f) {
						z += zDirection;
					}

					position = new Vector3(x,y,z);
				} else {
					float x = Mathf.RoundToInt (hit.point.x); 
					float y = Mathf.RoundToInt (hit.point.y);
					float z = Mathf.RoundToInt (hit.point.z);

					position = new Vector3(x,y+0.5f,z);					
				}
				Debug.Log("NEW CUBE AT "+position.ToString());				

				GameObject obj=Instantiate(prefab, position, Quaternion.identity) as GameObject;
			}
		}
	}
}
