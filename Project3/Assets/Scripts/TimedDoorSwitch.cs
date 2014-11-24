using UnityEngine;
using System.Collections;

public class TimedDoorSwitch : MonoBehaviour {

	float time = 0;
	public float timeLimit = 5f;
	const float scaleConst = 3.7f;
	float scale;
	bool on = false;
	public string doorTag;
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
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag (doorTag);
			for(int i = 0; i < DoorList.Length; ++i)
			{
				DoorList[i].GetComponent<Door>().open = false;
			}
		}
		if(on){
			time += Time.deltaTime;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		print ("collision");
		GameObject[] DoorList = GameObject.FindGameObjectsWithTag (doorTag);
		if(col.gameObject.CompareTag ("Player") && on == false && DoorList[0].GetComponent<Door>().open == false)
		{

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
