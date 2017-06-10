using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text connexText;

	public void updateConnex() {
		int connexComps = this.getConnexComponents();
		connexText.text = "Componentes conexas del frame: "+connexComps.ToString();
	}

	int getConnexComponents() {
		int t = VoxelController.currentFrame;
		bool dataExists = PlayerPrefs.HasKey("HIDEMO_frame_"+t);
		if(!dataExists) {
			return -1;
		}
		string levelData = PlayerPrefs.GetString("HIDEMO_frame_"+t);
		string[] voxels = levelData.Split(";"[0]);
		Debug.Log(levelData);
		return t;
	}
	
}
