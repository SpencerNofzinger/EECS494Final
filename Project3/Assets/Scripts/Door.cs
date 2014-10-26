using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(open)
		{
			renderer.enabled = false;
			collider.enabled = false;
		}
		else
		{
			renderer.enabled = true;
			collider.enabled = true;
		}
	}
}
