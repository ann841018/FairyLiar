using UnityEngine;
using System.Collections;

public class Magic0 : MonoBehaviour {

	public float MagicSpeed = 0.1f;
	public int Magicpower = 10;
	private float timeM;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update ()
	{
		timeM = timeM + Time.deltaTime;
		transform.Translate (-MagicSpeed, 0, 0);
		if (timeM > 1)Destroy(gameObject);
	}
}
