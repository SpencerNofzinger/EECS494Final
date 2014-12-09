using UnityEngine;
using System.Collections;

public class ShoddyAnimator : MonoBehaviour {
	public GameObject leftarm;
	public GameObject rightarm;
	public GameObject leftleg;
	public GameObject rightleg;

	private float movespeed = 400;
	private bool moving = false;
	private float currentTime = .25f;
	private float switchTime = .5f;

	private Quaternion laq;
	private Quaternion raq;
	private Quaternion llq;
	private Quaternion rlq;

	enum Movement
	{
		FORWARD,
		BACKWARD,
		RIGHT,
		LEFT,
		FALLING,
		IDLE
	};
	Movement mov;

	void Start()
	{
		mov = Movement.IDLE;
		laq = leftarm.transform.localRotation;
		raq = rightarm.transform.localRotation;
		llq = leftleg.transform.localRotation;
		rlq = rightleg.transform.localRotation;
	}

	// Update is called once per frame
	void Update () {
		switch (mov) {
		case Movement.FORWARD:
			forward ();
			break;
		case Movement.BACKWARD:
			break;
		case Movement.RIGHT:
			strafeRight ();
			break;
		case Movement.LEFT:
			strafeLeft ();
			break;
		case Movement.FALLING:
			break;
		case Movement.IDLE:
		default:
			//forward ();
			break;
		}
		if(moving)
		{
			currentTime += Time.deltaTime;
			if(currentTime > switchTime)
			{
				movespeed = -movespeed;
				currentTime = 0;
			}
		}
	}

	void forward()
	{	
		rightleg.transform.Rotate (Vector3.right * movespeed * Time.deltaTime);
		leftleg.transform.Rotate (Vector3.right * -movespeed * Time.deltaTime);
		leftarm.transform.Rotate (Vector3.up * .5f * movespeed * Time.deltaTime);
		rightarm.transform.Rotate (Vector3.up * .5f * movespeed * Time.deltaTime);
	}
	void strafeRight()
	{
		rightleg.transform.Rotate (Vector3.right * -.2f*movespeed * Time.deltaTime);
		leftleg.transform.Rotate (Vector3.right * .2f*movespeed * Time.deltaTime);
		rightleg.transform.Rotate (Vector3.forward * -.5f*movespeed * Time.deltaTime * 
		                           ( Mathf.Floor (4 * currentTime) % 2 + 
		 							-((Mathf.Floor (4 * currentTime)+.5f) % 2)) );
		leftleg.transform.Rotate (Vector3.forward * -.7f*movespeed * Time.deltaTime);
		leftarm.transform.Rotate (Vector3.forward * .1f * movespeed * Time.deltaTime);
		rightarm.transform.Rotate (Vector3.forward * .1f * movespeed * Time.deltaTime);
	}
	void strafeLeft()
	{
		rightleg.transform.Rotate (Vector3.right * .2f*movespeed * Time.deltaTime);
		leftleg.transform.Rotate (Vector3.right * -.2f*movespeed * Time.deltaTime);
		leftleg.transform.Rotate (Vector3.forward * .5f*movespeed * Time.deltaTime * 
		                           ( Mathf.Floor (4 * currentTime) % 2 + 
		 -((Mathf.Floor (4 * currentTime)+.5f) % 2)) );
		rightleg.transform.Rotate (Vector3.forward * .7f*movespeed * Time.deltaTime);
		leftarm.transform.Rotate (Vector3.forward * .1f * movespeed * Time.deltaTime);
		rightarm.transform.Rotate (Vector3.forward * .1f * movespeed * Time.deltaTime);
	}

	int fix = 0;
	public void startForward()
	{
		fix = 0;
		if(mov != Movement.FORWARD)
		{
			startIdle ();
			moving = true;
			currentTime = switchTime / 2.0f;
			mov = Movement.FORWARD;
		}
	}
	public void startRight()
	{
		fix += 1;
		if(mov != Movement.RIGHT && fix > 1)
		{
			startIdle();
			moving = true;
			currentTime = switchTime / 2.0f;
			mov = Movement.RIGHT;
		}
	}
	public void startLeft()
	{
		fix += 1;
		if(mov != Movement.LEFT && fix > 1)
		{
			startIdle ();
			moving = true;
			currentTime = switchTime / 2.0f;
			mov = Movement.LEFT;
		}
	}
	public void startIdle()
	{
		moving = false;
		mov = Movement.IDLE;
		leftarm.transform.localRotation = laq;
		rightarm.transform.localRotation = raq;
		leftleg.transform.localRotation = llq;
		rightleg.transform.localRotation = rlq;
	}

	public void disappear()
	{
		leftarm.GetComponentInChildren<Renderer> ().enabled = false;
		leftleg.GetComponentInChildren<Renderer> ().enabled = false;
		rightarm.GetComponentInChildren<Renderer> ().enabled = false;
		rightleg.GetComponentInChildren<Renderer> ().enabled = false;
	}
	public void reappear()
	{
		leftarm.GetComponentInChildren<Renderer> ().enabled = true;
		leftleg.GetComponentInChildren<Renderer> ().enabled = true;
		rightarm.GetComponentInChildren<Renderer> ().enabled = true;
		rightleg.GetComponentInChildren<Renderer> ().enabled = true;
	}
}
