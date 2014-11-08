using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	
	private Vector3 curLoc;
	private GameObject prevLoc;
	public float moveSpeed = 2;
	public float rotateSpeed;
	private bool set;
	public GameObject marker;
	public GameObject teleportArriveEffect;
	
	// Camera variables
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isRotating;	// Is the camera being rotated?
	private float turnSpeed = 4.0f;
	
	// Camera transition variables
	private bool isTeleporting;
	private Vector3 teleportStartPosition;
	private Vector3 teleportEndPosition;
	private float warpTime = 0.0f;
	private float maxWarpTime = 0.8f;
	
	private bool inputEnabled = true;
	
	void Update () 
	{
		if (inputEnabled) {
			InputListen ();
			Poof ();
		}
		
		if (isTeleporting) {
			renderer.enabled = false;
			collider.enabled = false;
			inputEnabled = false;
			transform.position = Vector3.Lerp (transform.position, teleportEndPosition, warpTime / maxWarpTime);
			warpTime += Time.deltaTime;
			if (Vector3.Distance (transform.position, teleportEndPosition) < .5f){
				isTeleporting = false;
				inputEnabled = true;
				transform.position = teleportEndPosition;
				rigidbody.velocity = Vector3.zero;
				Instantiate (teleportArriveEffect, transform.position, Quaternion.identity);
				renderer.enabled = true;
				collider.enabled = true;
				warpTime = 0;
				
			}
			
		}
	}
	
	private void InputListen() {
		curLoc = transform.position;
		
		Vector3 velocity = Vector3.zero;
		velocity.y = rigidbody.velocity.y;
		if(Input.GetKey(KeyCode.A))
		{
			velocity += Vector3.Cross (transform.forward, Vector3.up) * moveSpeed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			velocity += Vector3.Cross (transform.forward, Vector3.up) * -moveSpeed;
		}
		if(Input.GetKey(KeyCode.W))
		{
			velocity += transform.forward * moveSpeed;
		}
		if(Input.GetKey(KeyCode.S))
		{
			velocity += transform.forward * -moveSpeed;
		}
		if(Input.GetKey (KeyCode.Escape))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		
		// Rotate player based on mouse
		transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis ("Mouse X"));
		
		// Camera stuff
		/*
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isRotating = true;
		}
		if (!Input.GetMouseButton(0)) isRotating=false;

		if (isRotating)
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			//transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
			transform.RotateAround(transform.position, Vector3.up, -pos.x * turnSpeed);

		}
		*/
		// end camera stuff
		
		
		//if(Input.GetKey(KeyCode.Space))
		//curLoc.y += 2* moveSpeed * Time.fixedDeltaTime;
		transform.rigidbody.velocity = velocity;
		
	}
	
	private void Poof() {
		if(Input.GetKeyUp(KeyCode.Mouse1)) {
			if(set) {
				Destroy(prevLoc);
			}
			prevLoc = Instantiate(marker, curLoc, Quaternion.identity) as GameObject;
			set = true;
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)) {
			if(set) {
				
				//transform.position = prevLoc.transform.position;
				set = false;
				isTeleporting = true;
				teleportStartPosition = transform.position;
				teleportEndPosition = GameObject.FindGameObjectWithTag("Marker").transform.position;
				Destroy(prevLoc);
			}
		}
	}
	
	void OnCollisionEnter (Collision hit) { 
		if(hit.gameObject.CompareTag ("MovingPlatform"))
		{
			transform.parent = hit.gameObject.transform.parent; 
		}
	}
	void OnCollisionExit(Collision hit){
		if(hit.gameObject.CompareTag ("MovingPlatform"))
		{
			transform.parent = null; 
		}
	}
}
