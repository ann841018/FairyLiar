using UnityEngine;
using System.Collections;

public class followCam : MonoBehaviour {
	
	public Transform myTarget;
	public Vector3 myFocus;
	private Camera myCam;
	public float mySmoothTime;
	public Vector3 velocity;

	// Use this for initialization
	void Start ()
	{
		myCam = this.gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = myCam.WorldToViewportPoint (myTarget.position);
		if (myTarget.position.x >= -13 && myTarget.position.x < 4)
		{
			Vector3 distance = myTarget.position - myCam.ViewportToWorldPoint (new Vector3 (myFocus.x,pos.y, pos.z));
			Vector3 moveto = transform.position + distance;
			transform.position = Vector3.SmoothDamp (transform.position, moveto, ref velocity, mySmoothTime);
		}
	}
}
