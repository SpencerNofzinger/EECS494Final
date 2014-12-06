using UnityEngine;
using System.Collections;

public class RedBridgeSwitch : MonoBehaviour {
	
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
			GameObject[] BridgeList = GameObject.FindGameObjectsWithTag ("RedBridge");
			for(int i = 0; i < BridgeList.Length; ++i)
			{
				BridgeList[i].GetComponent<Bridge>().vertical = !BridgeList[i].GetComponent<Bridge>().vertical;
			}
			audio.Play();
		}
	}
}
