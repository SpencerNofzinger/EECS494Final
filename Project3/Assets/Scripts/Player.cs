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
	GameObject HaloEffectObject;
	public GameObject teleportHaloEffect;
	
	// Camera variables
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isRotating;	// Is the camera being rotated?
	private float turnSpeed = 4.0f;
	private Vector3 defaultCameraPosition;
	
	// Camera transition variables
	private bool isTeleporting;
	private Vector3 teleportStartPosition;
	private Vector3 teleportEndPosition;
	private float warpTime = 0.0f;
	private float maxWarpTime = 0.8f;
	
	private bool inputEnabled = true;

	// Model child
	private GameObject model;
	private GameObject modelmeshobject;

	// Animator
	private Animator anim;
	private float fallpoint = -.1f;
	private float fallpoint2 = -1f;
	private Vector3 diagleft = new Vector3(0, 315, 0);
	private Vector3 diagright = new Vector3(0, 90, 0);

	void Awake(){
		defaultCameraPosition = Camera.main.transform.localPosition;
		Screen.showCursor = false;
		Screen.lockCursor = true;
		model = transform.GetChild (0).gameObject;
		modelmeshobject = model.transform.GetChild (0).gameObject;
		anim = model.GetComponent<Animator> ();
		}
	void Update () 
	{
		if (rigidbody.velocity == Vector3.zero) 
		{
			anim.Play ("idle");		
		}
		else if(rigidbody.velocity.y < fallpoint2)
		{
			anim.Play ("fall");
		}

		CameraCheck ();
		if (inputEnabled) {
			InputListen ();
			Poof ();
		}
		
		if (isTeleporting) {
			// Turn renderer and collider off
			modelmeshobject.GetComponent<TurnMeshOff>().off ();
			collider.enabled = false;
			inputEnabled = false;
			transform.position = Vector3.Lerp (transform.position, prevLoc.transform.position, warpTime / maxWarpTime);
			warpTime += Time.deltaTime;
			HaloEffectObject.transform.position = transform.position;
			if (Vector3.Distance (transform.position, prevLoc.transform.position) < .5f){
				isTeleporting = false;
				inputEnabled = true;
				transform.position = prevLoc.transform.position;
				rigidbody.velocity = Vector3.zero;
				Instantiate (teleportArriveEffect, transform.position, Quaternion.identity);
				modelmeshobject.GetComponent<TurnMeshOff>().on ();
				collider.enabled = true;
				warpTime = 0;
				Destroy (prevLoc);
				prevLoc = null;
				Destroy (HaloEffectObject);
				HaloEffectObject = null;
			}
			
		}
	}
	/*
	private void CameraCheck(){
		RaycastHit hit;
		Ray cameraToPlayer = new Ray(transform.position, Camera.main.transform.position - transform.position);
		int layerMask = 1 << 8;
		layerMask += 1 << 9;
		layerMask += 1 << 2;
		layerMask = ~layerMask;
		if (Physics.Raycast (cameraToPlayer, out hit, 7.0f, layerMask)) {
			Camera.main.transform.position = hit.point;
				} else {
					Camera.main.transform.localPosition = defaultCameraPosition;
				}
	}*/

	/*private void CameraCheck(){
		RaycastHit[] hits;
		Ray cameraToPlayer = new Ray(transform.position, Camera.main.transform.position - transform.position);
		int layerMask = 1 << 8;
		layerMask += 1 << 9;
		layerMask += 1 << 2;
		layerMask = ~layerMask;
		hits = Physics.RaycastAll (cameraToPlayer, 7.0f, layerMask);

		for (int i = 0; i < hits.Length; ++i){
			RaycastHit hit = hits[i];
			Renderer renderer = hit.collider.renderer;
			if (renderer) {
				AddTransparency AT = renderer.GetComponent<AddTransparency>();
				if (!AT){
					AT = renderer.gameObject.AddComponent<AddTransparency>();
				}
				AT.makeTransparent();

			}
		}
	}*/

	private void CameraCheck(){
		RaycastHit[] hits;
		int layerMask = 1 << 8;
		layerMask += 1 << 9;
		layerMask += 1 << 2;
		layerMask = ~layerMask;
		for (int playerPoint = 0; playerPoint < 4; playerPoint++) {
			Ray cameraToPlayer;
			Vector3 referencePosition = transform.position;
			if (playerPoint == 0){
				referencePosition.x += 0.45f * transform.localScale.x;
				referencePosition.y += 0.45f * transform.localScale.y;
			}
			if (playerPoint == 1){
				referencePosition.x += 0.45f * transform.localScale.x;
				referencePosition.y -= 0.45f * transform.localScale.y;
			}
			if (playerPoint == 2){
				referencePosition.x -= 0.45f * transform.localScale.x;
				referencePosition.y += 0.45f * transform.localScale.y;
			}
			if (playerPoint == 3){
				referencePosition.x -= 0.45f * transform.localScale.x;
				referencePosition.y -= 0.45f * transform.localScale.y;
			}

			cameraToPlayer = new Ray (referencePosition, Camera.main.transform.position - transform.position);

			hits = Physics.RaycastAll (cameraToPlayer, 7.0f, layerMask);
				
			for (int i = 0; i < hits.Length; ++i) {
					RaycastHit hit = hits [i];
					Renderer renderer = hit.collider.renderer;
					if (renderer) {
							AddTransparency AT = renderer.GetComponent<AddTransparency> ();
							if (!AT) {
									AT = renderer.gameObject.AddComponent<AddTransparency> ();
							}
							AT.makeTransparent ();
					}
			}
		}
	}

	private void InputListen() {
		curLoc = transform.position;
		
		Vector3 velocity = Vector3.zero;
		velocity.y = rigidbody.velocity.y;
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			velocity += Vector3.Cross (transform.forward, Vector3.up) * moveSpeed;
		}
		if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
		{
			velocity += Vector3.Cross (transform.forward, Vector3.up) * -moveSpeed;
		}
		if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			if(rigidbody.velocity.y > fallpoint)
			{
				anim.Play ("forward");
			}
			velocity += transform.forward * moveSpeed;
		}
		if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
		{
			if(rigidbody.velocity.y > fallpoint)
			{
				anim.Play ("backward");
			}
			velocity += transform.forward * -moveSpeed;
		}
		if(Input.GetKey (KeyCode.Escape))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		if(Input.GetKey(KeyCode.P))
		{
			Screen.lockCursor = !Screen.lockCursor;
		}

		// Animations ====================================
		// no movement
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			anim.Play ("idle");
			model.transform.rotation = transform.rotation;
		}

		// left only
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			anim.Play ("strafe_left");
			model.transform.rotation = transform.rotation;
		}
		// right only
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			anim.Play ("strafe_right");
			model.transform.rotation = transform.rotation;
		}

		// forward only
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			anim.Play ("forward");
			model.transform.rotation = transform.rotation;
		}

		// backward only
		if(!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			anim.Play ("backward");
			model.transform.rotation = transform.rotation;
		}

		// diagonal right forward
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			set_model_y_rot (45);
		}

		// diagonal left forward
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
		   && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			set_model_y_rot (315);
		}

		// diagonal right backward
		if(!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			set_model_y_rot (315);
		}

		// diagonal left backward
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)
		   && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D)
		   && rigidbody.velocity.y > fallpoint)
		{
			set_model_y_rot (45);
		}


		// Rotate player based on mouse
		transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis ("Mouse X"));


		transform.rigidbody.velocity = velocity;
		
	}
	
	private void Poof() {
		if(Input.GetKeyUp(KeyCode.Mouse1)) {
			if(set) {
				Destroy(prevLoc);
			}
			prevLoc = Instantiate(marker, curLoc, Quaternion.identity) as GameObject;
			prevLoc.transform.parent = transform.parent;
			set = true;
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)) {
			if(set) {
				
				//transform.position = prevLoc.transform.position;
				set = false;
				isTeleporting = true;
				teleportStartPosition = transform.position;
				HaloEffectObject = Instantiate(teleportHaloEffect, curLoc, Quaternion.identity) as GameObject;
				//HaloEffectObject.transform.parent = transform;
				prevLoc.GetComponent<Marker>().setInvis();
			}
		}
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

	private void set_model_y_rot(float y)
	{
		Vector3 euler;
		euler.x = 0;
		euler.z = 0;
		euler.y = transform.rotation.eulerAngles.y + y; 
		model.transform.rotation = Quaternion.Euler (euler);
	}
}
