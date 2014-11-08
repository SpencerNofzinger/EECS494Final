using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	public enum collType {Sphere, Cube};
	public collType type;
	GUIText text;

	// Use this for initialization
	void Start () {
		if (type == collType.Sphere) {
			var myCollider = this.gameObject.AddComponent(typeof(SphereCollider));
			(myCollider as SphereCollider).radius = 0.5f;
		} if (type == collType.Cube) {
			var myCollider = this.gameObject.AddComponent(typeof(BoxCollider));
			(myCollider as BoxCollider).size = new Vector3(1.0f, 1.0f, 1.0f);
		}
		this.gameObject.collider.isTrigger = true;
		this.gameObject.collider.enabled = true;
		text = this.gameObject.GetComponentInChildren<GUIText> ();
		text.guiText.enabled = false;
	}
	
	void OnTriggerEnter () {
		text.guiText.enabled = true;
	}

	void OnTriggerExit () {
		text.guiText.enabled = false;
	}
}
