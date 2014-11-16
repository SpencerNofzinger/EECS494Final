using UnityEngine;
using System.Collections;

public class TimedDoorSwitch : MonoBehaviour {

	float time = 0;
	bool on = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(time > 3){
			on = false;
			time = 0;
		}
		if(on){
			time += Time.deltaTime;
		}
		else{
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag ("Door");
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
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag ("Door");
			for(int i = 0; i < DoorList.Length; ++i)
			{
				DoorList[i].GetComponent<Door>().open = true;
			}
			on = true;
			print("here");
		}
	}
}
