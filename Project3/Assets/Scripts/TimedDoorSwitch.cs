using UnityEngine;
using System.Collections;

public class TimedDoorSwitch : MonoBehaviour {

	float time = 0;
	public float timeLimit = 5f;
	const float scaleConst = 5.5f;
	float scale;
	bool on = false;
	// Use this for initialization
	void Start () {
		scale = scaleConst / timeLimit;
		audio.pitch = scale;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(time > timeLimit){
			on = false;
			time = 0;
		}
		if(on){
			time += Time.deltaTime;
		}
		else{
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag ("DoorTimed");
			for(int i = 0; i < DoorList.Length; ++i)
			{
				DoorList[i].GetComponent<Door>().open = false;
			}
		}
		
	}
	void OnTriggerEnter(Collider col)
	{
		print ("collision");
		if(col.gameObject.CompareTag ("Player") && on == false)
		{
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag ("DoorTimed");
			for(int i = 0; i < DoorList.Length; ++i)
			{
				DoorList[i].GetComponent<Door>().open = true;
			}
			on = true;
			audio.Play ();
			//GetComponent<AudioSource>().PlayOneShot (5);
			print("here");
		}
	}
}
