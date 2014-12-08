using UnityEngine;
using System.Collections;

public class MiniMapBorder : MonoBehaviour {
	private GUITexture thisTexture;

	// Use this for initialization
	void Start () {
		thisTexture = gameObject.GetComponent<GUITexture> ();
		thisTexture.pixelInset = new Rect (Screen.width - 212, Screen.height - 212, 212, 212);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
