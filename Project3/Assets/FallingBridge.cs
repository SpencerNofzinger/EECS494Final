using UnityEngine;
using System.Collections;

public class FallingBridge : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += velocity * Time.deltaTime;
	}
	void OnCollisionExit(Collision col){
		if(col.collider.gameObject.CompareTag("Player")){
			velocity.y = -9.8f;
		}
			
	}
}
