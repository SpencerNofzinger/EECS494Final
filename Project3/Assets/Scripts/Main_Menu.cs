using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {
//	public Texture btnTexture;
	public string first_scene;
	public string scene_select;
	float mid_width;
	float mid_height;
	float start_width = 100;
	float start_height = 50;
	float select_width = 100;
	float select_height = 50;

	void Start () {
		mid_width = Screen.width / 2;
		mid_height = Screen.height / 2;
	}

	void OnGUI () {
//		if (!btnTexture) {
//			Debug.LogError("Please assign a texture on the inspector");
//			return;
//		}
		if (GUI.Button(new Rect(mid_width - start_width / 2, mid_height - start_height / 2, start_width, start_height), "Start")) {
//			Debug.Log("Clicked the button with an image");
			Application.LoadLevel (first_scene);
		}

		if (GUI.Button(new Rect(mid_width - select_width / 2, mid_height + select_height / 2 + start_height, select_width, select_height), "Stage Select")) {
//			Debug.Log("Clicked the button with text");
			Application.LoadLevel (scene_select);
		}
	}
}
