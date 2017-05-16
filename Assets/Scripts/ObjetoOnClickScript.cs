using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOnClickScript : MonoBehaviour {

	RaycastHit hit;
	public GameObject prefab;
	public string mode = "ADD";

	public void SetMode(string newMode) {
		mode = newMode;
	}

	void Update () {
		// lanzamos un rayo desde la posicion del raton
		// y en la direccion en la que mira la camara
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit)) {
			if(Input.GetMouseButtonDown(1)) {
				GameObject.Destroy(hit.transform.gameObject);				
			}
			if(Input.GetMouseButtonDown(0)) {
				Vector3 position = Vector3.zero;
				Vector3 objectCenter = hit.transform.position;

				if(hit.transform.gameObject.tag == "Cube") {
					// si hemos chocado con un cubo
					// calculamos la distancia desde el punto de click
					// hasta el centro del cubo
					// para obtener la direccion en que queremos colocar el nuevo cubo
					Vector3 fromCenterToClickPoint = hit.point - objectCenter;
					
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
					// si no hemos chocado con un cubo asumimos
					// que hemos chocado con el plano
					// y simplemente redondeamos las coordenadas
					float x = Mathf.RoundToInt (hit.point.x); 
					float y = Mathf.RoundToInt (hit.point.y);
					float z = Mathf.RoundToInt (hit.point.z);

					position = new Vector3(x,y+0.5f,z);					
				}
				Debug.Log("NEW CUBE AT "+position.ToString());				

				GameObject obj=Instantiate(prefab, position, Quaternion.identity) as GameObject;					
				/*
				if(mode == "ADD") {
				} else if(mode == "DELETE") {
					GameObject.Destroy(hit.transform.gameObject);
				}
				*/
			}
		}
	}
}
