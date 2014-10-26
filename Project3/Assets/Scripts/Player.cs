using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 curLoc;
	private GameObject prevLoc;
	public float moveSpeed = 2;
	private bool set;
	public GameObject marker;

	void Update () 
	{
		InputListen 	();
		Poof ();
	}
	
	private void InputListen() {
		curLoc = transform.position;

		Vector3 velocity = Vector3.zero;
		if(Input.GetKey(KeyCode.A))
		{
			velocity.x = -moveSpeed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			velocity.x = moveSpeed;
		}
		if(Input.GetKey(KeyCode.W))
		{
			velocity.z = moveSpeed;
		}
		if(Input.GetKey(KeyCode.S))
		{
			velocity.z = -moveSpeed;
		}
		//if(Input.GetKey(KeyCode.Space))
			//curLoc.y += 2* moveSpeed * Time.fixedDeltaTime;
		transform.rigidbody.velocity = velocity;
		
	}

	private void Poof() {
		if(Input.GetKeyUp(KeyCode.J)) {
			if(set) {
				Destroy(prevLoc);
				transform.position = prevLoc.transform.position;
				set = false;
			} else {
				prevLoc = Instantiate(marker, curLoc, Quaternion.identity) as GameObject;
				set = true;
			}
		}
	}
}
