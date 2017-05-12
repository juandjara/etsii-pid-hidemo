using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOnClickScript : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	public GameObject prefab;


	void Start () {




	}


	void Update () {

		ray=Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray,out hit))
		{

			if(Input.GetMouseButtonDown(0))
			{

				float x= Mathf.RoundToInt (hit.point.x); 
				float y= Mathf.RoundToInt(hit.point.y);
				float z= Mathf.RoundToInt(hit.point.z);
				
				GameObject obj=Instantiate(prefab,new Vector3(x+0.5f,y+0.5f,z+0.5f), Quaternion.identity) as GameObject;

			}

		}


}
}