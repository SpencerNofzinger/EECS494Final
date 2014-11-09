using UnityEngine;
using System.Collections;

public class LoopingMovingPlatform : MonoBehaviour {
	public Vector3 velocity;
	public float length;
	Vector3 startPos;
	bool forward = true;
	bool paused = false;
	float currentPauseTime = 0;
	public float pauseTime = 0;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!paused){
			Vector3 pos = transform.position;
			pos += velocity * Time.deltaTime;
			transform.position = pos;
			if(forward && Vector3.Distance (transform.position, startPos) > length)
			{
				velocity = -velocity;
				forward = false;
				paused = true;
			}
			if(!forward && Vector3.Distance (transform.position, startPos) < .1f)
			{
				velocity = -velocity;
				transform.position = startPos;
				forward = true;
				paused = true;
			}
		}
		else{
			currentPauseTime += Time.deltaTime;
			if(currentPauseTime > pauseTime)
			{
				currentPauseTime = 0;
				paused = false;
			}
		}
	}
}
