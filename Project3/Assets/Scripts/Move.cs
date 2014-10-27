using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Vector3 speed;
	Vector3 oriPos;
	float totalDist = 0.0f;
	float maxDist = 55.0f;

	// Use this for initialization
	void Start () {
		speed = rigidbody.velocity;
		speed.z = -10.0f;
		oriPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = speed;
		totalDist += Mathf.Abs (speed.z) * Time.deltaTime;
		if((oriPos - transform.position).magnitude > maxDist) {
			Destroy(gameObject);
		}
	}
}
