﻿using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public string nextLevel;

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
			print("here");
			Application.LoadLevel (nextLevel);
		}
	}
}
