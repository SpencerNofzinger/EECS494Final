using UnityEngine;
using System.Collections;

public class InstructionList : MonoBehaviour {
	int inUse;
	GUIText[] list;
	bool showGUI;
	//GUIStyle guiStyle;

	void Start () {
		list = this.GetComponentsInChildren<GUIText> ();
		for (int i = 0; i < list.Length; i++) {
			list[i].transform.position = new Vector3(0f, 1f, 0f);
			list[i].enabled = false;
		}
		inUse = -1;
		//guiStyle = new GUIStyle();
		//guiStyle.fontSize = 24;
	}

	public void Enter (int i) {
		if (inUse == -1) {
			showGUI = true;
			inUse = i;
		} else {
			showGUI = true;
			inUse = i;
		}
	}

	public void Exit (int i) {
		showGUI = false;
		inUse = -1;
	}

	void OnGUI() {
		if(showGUI) {
			int width = 200, height = 50;	
			GUI.Box(new Rect((Screen.width - width)/2, Screen.height/4 - height, width, height), list[inUse].text);
			//GUI.Box(new Rect((Screen.width - width)/2, Screen.height - height, width, height), list[inUse].text, guiStyle);
		}
	}
}
