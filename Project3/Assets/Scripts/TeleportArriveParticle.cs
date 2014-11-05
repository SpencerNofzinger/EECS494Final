using UnityEngine;
using System.Collections;

public class TeleportArriveParticle : MonoBehaviour {
	public float aliveTime = 10f;
	float currentTime = 0f;
	
	// Update is called once per frame
	void Update () {
		if(currentTime > aliveTime)
		{
			Destroy (this.gameObject);
		}
		currentTime += Time.deltaTime;
	}
}
