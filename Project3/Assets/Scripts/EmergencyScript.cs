using UnityEngine;
using System.Collections;

public class EmergencyScript : MonoBehaviour {
	bool shown = false;
	int inUse;
	GUIText[] list;
	bool showGUI;
	GUIStyle guiStyle;

	void Start () {
		list = this.GetComponentsInChildren<GUIText> ();
		for (int i = 0; i < list.Length; i++) {
			list[i].transform.position = new Vector3(0f, 1f, 0f);
			list[i].enabled = false;
		}
		inUse = 0;
	}
	IEnumerator DisapearBoxAfter() {
		// suspend execution for waitTime seconds
		yield return new WaitForSeconds (6.0f);
		shown = true;
	}

	void OnGUI () {
		if(!shown) {
			guiStyle = new GUIStyle(GUI.skin.button);
			guiStyle.fontSize = 24;
			int width = 500, height = 100;	
			
			GUI.Box(new Rect((Screen.width - width)/2, Screen.height/4 - height, width, height), list[inUse].text, guiStyle);
		}
//		if (shown) {
			StartCoroutine(DisapearBoxAfter()); 
//		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
