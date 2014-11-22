using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {
	public string doorTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag ("Player"))
	 	{
			GameObject[] DoorList = GameObject.FindGameObjectsWithTag (doorTag);
			for(int i = 0; i < DoorList.Length; ++i)
			{
				DoorList[i].GetComponent<Door>().open = !DoorList[i].GetComponent<Door>().open;
			}
		}
	}
}
