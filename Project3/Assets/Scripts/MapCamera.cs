using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour {
	private float width = 500f;
	private float height = 500f;
	// Use this for initialization
	void Start () {
		gameObject.camera.pixelRect = new Rect ((Screen.width - width) / 2, (Screen.height - height) / 2, width, height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
