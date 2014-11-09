using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	public enum collType {Sphere, Cube};
	public collType type;
	public GUIText text;
	public GameObject list;
	public int instructNum;
	InstructionList actualList;

	void Awake () {
		actualList = list.GetComponent<InstructionList> ();
	}

	// Use this for initialization
	void Start () {
		if (type == collType.Sphere) {
			var myCollider = this.gameObject.AddComponent(typeof(SphereCollider));
			(myCollider as SphereCollider).radius = 0.5f;
		} if (type == collType.Cube) {
			var myCollider = this.gameObject.AddComponent(typeof(BoxCollider));
			(myCollider as BoxCollider).size = new Vector3(0.9f, 0.9f, 0.9f);
		}
		this.gameObject.collider.isTrigger = true;
		this.gameObject.collider.enabled = true;
	}
	
	void OnTriggerEnter (Collider coll) {
		if(coll == GameObject.FindGameObjectWithTag("Player").collider) {
			actualList.Enter (instructNum);
		}
	}

	void OnTriggerExit (Collider coll) {
		if(coll == GameObject.FindGameObjectWithTag("Player").collider) {
			actualList.Exit (instructNum);
		}
	}
}
