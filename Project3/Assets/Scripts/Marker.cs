using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision hit) { 
		if(hit.gameObject.CompareTag ("MovingPlatform"))
		{
			transform.parent = hit.gameObject.transform; 
		}
		else if(hit.gameObject.CompareTag ("RotatingPlatform"))
		{
			transform.parent = hit.gameObject.transform.parent; 
		}
	}
	void OnCollisionExit(Collision hit){
		if(hit.gameObject.CompareTag ("MovingPlatform"))
		{
			transform.parent = null; 
		}
		else if(hit.gameObject.CompareTag ("RotatingPlatform"))
		{
			transform.parent = null;
		}
	}

	public void setInvis(){
		renderer.enabled = false;
	}
}
