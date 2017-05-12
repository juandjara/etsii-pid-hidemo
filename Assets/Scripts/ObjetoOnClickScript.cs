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
				Vector3 objectCenter = hit.transform.position;
				Vector3 fromCenterToClickPoint = hit.point - objectCenter;

				float x = Mathf.RoundToInt (hit.point.x); 
				float y = Mathf.RoundToInt (hit.point.y);
				float z = Mathf.RoundToInt (hit.point.z);
				
				float xDirection = Mathf.Sign(fromCenterToClickPoint.x);
				float yDirection = Mathf.Sign(fromCenterToClickPoint.y);
				float zDirection = Mathf.Sign(fromCenterToClickPoint.z);

				Vector3 direction = new Vector3(xDirection*0.5f, yDirection*0.5f, zDirection*0.5f);

				Vector3 position = new Vector3(x+0.5f,y+0.5f,z+0.5f);

				GameObject obj=Instantiate(prefab, position + direction, Quaternion.identity) as GameObject;
			}
		}
	}
}
