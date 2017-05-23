using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoxelController : MonoBehaviour {

	RaycastHit hit;
	int currentFrame = 0;

	public GameObject prefab;
	public Slider slider;

	//void Start() {
	//	loadFrame(0);
	//}

	public void SaveCurrentFrame() {
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
		string frame = "";
		foreach(GameObject cube in cubes) {
			Vector3 center = cube.transform.position;
			frame += center.x+" "+center.y+" "+center.z+";";
		}
		PlayerPrefs.SetString("HIDEMO_frame_"+currentFrame, frame);
	}

	public void loadFrame(int frame) {
		//currentFrame = frame;
		currentFrame = (int) slider.value;
		// destruye todos los cubos de la escena
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
		foreach(GameObject cube in cubes) {
			GameObject.Destroy(cube);
		}
		// lee los datos guardados y si no hay sal de la funcion
		bool dataExists = PlayerPrefs.HasKey("HIDEMO_frame_"+currentFrame);
		if(!dataExists) {
			return;
		}
		string levelData = PlayerPrefs.GetString("HIDEMO_frame_"+currentFrame);
		string[] voxels = levelData.Split(";"[0]);
		// itera sobre cada voxel
		foreach(string voxel in voxels) {
			string[] coords = voxel.Split(" "[0]);
			// no crees un cubo si hay menos de tres coordenadas
			if(coords.Length >= 3) {
				float x = float.Parse(coords[0]);
				float y = float.Parse(coords[1]);
				float z = float.Parse(coords[2]);
				createCube(new Vector3(x,y,z));
			}			
		}
	}

	void createCube(Vector3 position) {
		Quaternion rotation = Quaternion.identity;
		GameObject obj = Instantiate(prefab, position, rotation) as GameObject;							
	}

	void Update () {
		// lanzamos un rayo desde la posicion del raton
		// y en la direccion en la que mira la camara
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit)) {
			bool isCube = hit.transform.gameObject.tag == "Cube";
			// si pulsamos el boton derecho borramos voxels
			if(Input.GetMouseButtonDown(1) && isCube) {
				GameObject.Destroy(hit.transform.gameObject);
				// TODO: Cambiar modelo para poder borrar cubos
			}
			// si pulsamos el boton izquierdo añadimos voxels
			if(Input.GetMouseButtonDown(0)) {
				Vector3 position = Vector3.zero;
				Vector3 objectCenter = hit.transform.position;

				if(isCube) {
					// si hemos chocado con un cubo
					// calculamos la distancia desde el punto de click
					// hasta el centro del cubo
					// para obtener la direccion en que queremos colocar el nuevo cubo
					Vector3 fromCenterToClickPoint = hit.point - objectCenter;
					
					// la posicion del nuevo cubo empieza en el cubo pulsado
					float x = (objectCenter.x); 
					float y = (objectCenter.y);
					float z = (objectCenter.z);
					
					float xDirection = Mathf.Sign(fromCenterToClickPoint.x);
					float yDirection = Mathf.Sign(fromCenterToClickPoint.y);
					float zDirection = Mathf.Sign(fromCenterToClickPoint.z);

					// y se añade una unidad en cada coordenada
					// de la direccion calculada previamente
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
					float x = Mathf.FloorToInt (hit.point.x) + 0.5f; 
					float y = 0.5f;
					float z = Mathf.FloorToInt (hit.point.z) + 0.5f;

					position = new Vector3(x,y,z);					
				}
				Debug.Log("NEW CUBE AT "+position.ToString());
				createCube(position);
			}
		}
	}
}
