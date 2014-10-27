using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject spawnObject;
	float spawnTime;

	void Start () {
		spawnTime = 3.0f;
	}

	// Update is called once per frame
	void Update () {
		if (spawnTime > 5.0f) {
			Instantiate (spawnObject, transform.position, Quaternion.identity);
			spawnTime = 0.0f;
		}
		spawnTime += Time.deltaTime;
	}
}
