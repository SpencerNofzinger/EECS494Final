using UnityEngine;
using System.Collections;

public class MovingPlatformSwitch : MonoBehaviour {
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag ("Player"))
		{
			GameObject[] PlatList = GameObject.FindGameObjectsWithTag ("MovingPlatform");
			for(int i = 0; i < PlatList.Length; ++i)
			{
				PlatList[i].GetComponent<LoopingMovingPlatform>().switchOn();
			}
		}
	}
}
