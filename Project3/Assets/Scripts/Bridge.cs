using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	public bool vertical;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(vertical)
		{
			Quaternion q = Quaternion.identity;
			q.SetLookRotation(Vector3.right);
			transform.rotation = q;
		}
		else
		{
			Quaternion q = Quaternion.identity;
			q.SetLookRotation(Vector3.forward);
			transform.rotation = q;
		}
	}
}
