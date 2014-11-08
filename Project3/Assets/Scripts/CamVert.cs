using UnityEngine;
using System.Collections;

public class CamVert : MonoBehaviour {
	public float maxAngle;
	public float minAngle;
	public float sensitivity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform t = transform;
		t.Rotate (Vector3.right, sensitivity * -Input.GetAxis ("Mouse Y"));
		Vector3 newr = t.rotation.eulerAngles;
		//newr.y = 180;
		newr.z = 180;
		if(t.rotation.eulerAngles.x < minAngle)
		{
			newr.x = minAngle;
		}
		if(t.rotation.eulerAngles.x > maxAngle)
		{
			newr.x = maxAngle;
		}
		Quaternion q = Quaternion.Euler (newr);
		t.rotation = q;
		transform.rotation = t.rotation;

	}
}
