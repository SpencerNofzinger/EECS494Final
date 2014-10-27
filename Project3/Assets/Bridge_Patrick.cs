using UnityEngine;
using System.Collections;

public class Bridge_Patrick : MonoBehaviour {
	public bool vertical;

	public int rotation = 1;
	public bool originalPosition = true;

	// Use this for initialization
	void Start () {
	
	}

	public void clockwiseRotate(){
				Quaternion q = Quaternion.identity;
				
				if (rotation == 1) {
					q.SetLookRotation (Vector3.right);
					rotation = 2;

				}
				else if (rotation == 2) {
					q.SetLookRotation (Vector3.back);
					rotation = 3;
				}
				else if (rotation == 3) {
					q.SetLookRotation (Vector3.left);
					rotation = 4;
				}
				else if (rotation == 4) {
					q.SetLookRotation (Vector3.forward);
					rotation = 1;		
				}

				transform.rotation = q;
		}

	public void shiftZpos(){
		Vector3 pos = transform.position;
		if (originalPosition) {
						pos.z += 2.0f;
						originalPosition = false;
				}
		else {
				pos.z -= 2.0f;
				originalPosition = true;
		}
		transform.position = pos;
	}

		// Update is called once per frame
	void Update () {
		Quaternion q = Quaternion.identity;


		if (rotation == 2) {
			q.SetLookRotation (Vector3.right);
			//rotation = 2;
			
		}
		else if (rotation == 3) {
			q.SetLookRotation (Vector3.back);
			//rotation = 3;
		}
		else if (rotation == 4) {
			q.SetLookRotation (Vector3.left);
			//rotation = 4;
		}
		else if (rotation == 1) {
			q.SetLookRotation (Vector3.forward);
			//rotation = 1;		
		}




		transform.rotation = q;
	}
}
