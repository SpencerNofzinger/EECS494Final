﻿using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag ("Player"))
		{
			col.GetComponent<Player>().reload ();
		}
		if(col.gameObject.CompareTag ("Marker"))
		{
			Destroy(col.gameObject);
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponent<Player>().MarkerDestroyed();
		}
	}
}
