using UnityEngine;
using System.Collections;

public class InstructionList : MonoBehaviour {
	int inUse;
	GUIText[] list;
	bool showGUI;

	void Start () {
		list = this.GetComponentsInChildren<GUIText> ();
		for (int i = 0; i < list.Length; i++) {
			list[i].transform.position = new Vector3(0f, 1f, 0f);
			list[i].enabled = false;
		}
		inUse = -1;
	}

	public void Enter (int i) {
		Debug.Log ("inUse: " + inUse);
		if (inUse == -1) {
//			list[i].enabled = true;
			showGUI = true;
			inUse = i;
		} else {
//			list[inUse].enabled = false;
//			list[i].enabled = true;
			showGUI = true;
			inUse = i;
		}
	}

	public void Exit (int i) {
		Debug.Log ("inUse: " + inUse);
//		list[i].enabled = false;
		showGUI = false;
		inUse = -1;
	}

	void OnGUI() {
		if(showGUI) {
			int width = 200, height = 50;
			GUI.Box(new Rect((Screen.width - width)/2, 0, width, height), list[inUse].text);
//			        ToString ());
		}
	}
}
