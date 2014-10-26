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
		
		if(Input.GetKey(KeyCode.A))
		{
			curLoc.x -= moveSpeed * Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.D))
		{
			curLoc.x += moveSpeed * Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.W))
		{
			curLoc.z += moveSpeed * Time.fixedDeltaTime;
		}
		if(Input.GetKey(KeyCode.S))
		{
			curLoc.z -= moveSpeed * Time.fixedDeltaTime;
		}
		//if(Input.GetKey(KeyCode.Space))
			//curLoc.y += 2* moveSpeed * Time.fixedDeltaTime;
		transform.position = curLoc;
		
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
