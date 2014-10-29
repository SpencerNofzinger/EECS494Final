using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Vector3 curLoc;
	private GameObject prevLoc;
	public float moveSpeed = 2;
	public float rotateSpeed;
	private bool set;
	public GameObject marker;

	void Update () 
	{
		InputListen();
		Poof ();
	}
	
	private void InputListen() {
		curLoc = transform.position;

		Vector3 velocity = Vector3.zero;
		velocity.y = rigidbody.velocity.y;
		if(Input.GetKey(KeyCode.A))
		{
			/*
			Quaternion q = transform.rotation;
			q.y -= rotateSpeed * Time.deltaTime;
			transform.rotation = Vector3.zero;
			*/
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
		if(Input.GetKey (KeyCode.Escape))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		//if(Input.GetKey(KeyCode.Space))
			//curLoc.y += 2* moveSpeed * Time.fixedDeltaTime;
		transform.rigidbody.velocity = velocity;
		
	}

	private void Poof() {
		if(Input.GetKeyUp(KeyCode.J)) {
			if(set) {
				Destroy(prevLoc);
			}
			prevLoc = Instantiate(marker, curLoc, Quaternion.identity) as GameObject;
			set = true;
		}
		if(Input.GetKeyUp(KeyCode.K)) {
			if(set) {
				Destroy(prevLoc);
				transform.position = prevLoc.transform.position;
				set = false;
			}
		}
	}
}
