using UnityEngine;
using System.Collections;

public class LoopingMovingPlatform : MonoBehaviour {
	public Vector3 velocity;
	public float length;
	Vector3 startPos;
	bool forward = true;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos += velocity * Time.deltaTime;
		transform.position = pos;
		if(forward && Vector3.Distance (transform.position, startPos) > length)
		{
			velocity = -velocity;
			forward = false;
		}
		if(!forward && Vector3.Distance (transform.position, startPos) < .1f)
		{
			velocity = -velocity;
			transform.position = startPos;
			forward = true;
		}
	}
}
