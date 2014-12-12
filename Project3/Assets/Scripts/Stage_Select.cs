using UnityEngine;
using System.Collections;

public class Stage_Select : MonoBehaviour {
	public Texture[] btnTexture;
	public int[] stage_select;
	public int num_stage = 8;
	public string main_menu;

	//num_row * num_col = num_stage
	int num_row = 2; //Number of rows
	int num_col = 5; //Number of buttons per row

	float width;
	float height;
	float button_width = 150;
	float button_height = 100;

	// Use this for initialization
	void Start () {
		width = Screen.width;
		height = Screen.height;
	}

	void OnGUI () {
		if (btnTexture.Length < num_stage || stage_select.Length < num_stage) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}

		float total_width = 10 * button_width;
 
		for (int i = 0; i < num_row; i++) {
			for (int j = 0; j < num_col; j++) {
				int level = 5 * i + j;
				GUIContent content;
				if(level == 9) {
					content = new GUIContent ("Credits", btnTexture[level]);
				} else {
					content = new GUIContent ("Level " + (level + 1), btnTexture[level]);
				}

				if (GUI.Button(new Rect((width - total_width) / 0.5f + button_width / 2 + j * (button_width * 1.5f),
				                        height / 2 - button_height / 2 + i * (button_height * 1.2f),
				                        button_width,
				                        button_height), 
				               content)) {
					Application.LoadLevel (level + 1);
				}
				if (GUI.Button(new Rect(width / 2 - button_width / 2, height * 93 / 100 - 25, button_width, 50), "Return")) {
					Application.LoadLevel (main_menu);
				}
			}
		}
	}
}
