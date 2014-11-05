using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay (Collision hit) { 
		if(hit.gameObject.CompareTag ("MovingPlatform"))
		{
			transform.parent = hit.transform ; 
		}
		else
		{
			transform.parent = null;
		}
	}
}
