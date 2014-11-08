using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	public GameObject ParentObject;

	public bool vertical;
	bool prev;
	public float degreesPerSecond = 45f;
	public float rotationDegreesAmount = 90f;
	private float totalRotation = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//put this in function
		if(vertical){
			if(transform.rotation.eulerAngles.y < 90 || transform.rotation.eulerAngles.y > 355)
				rotate();
		}
		else {
			if(transform.rotation.eulerAngles.y > 0 && transform.rotation.eulerAngles.y < 95)
				rotate_back();
		}		
	}
	
	void rotate(){
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = 
		Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;
		if(totalRotation > rotationDegreesAmount){
			totalRotation = rotationDegreesAmount;
		}
	}
	
	void rotate_back(){
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = 
		Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation -= Time.deltaTime * degreesPerSecond;
		if(totalRotation < 0){
			totalRotation = 0;
		}
	}
	
}
