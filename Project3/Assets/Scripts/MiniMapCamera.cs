using UnityEngine;
using System.Collections;

public class MiniMapCamera : MonoBehaviour {
	private float xPos = 205f;
	private float yPos = 205f;
	private float width = 200f;
	private float height = 200f;

	// Use this for initialization
	void Start () {
		gameObject.camera.pixelRect = new Rect(Screen.width - xPos, Screen.height - yPos, width, height);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
