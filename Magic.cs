using UnityEngine;
using System.Collections;

public class Magic : MonoBehaviour {

	public float MagicSpeed = 0.2f;
	public int Magicpower = 10;
	private float timeM;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update ()
	{
		timeM = timeM + Time.deltaTime;
		transform.Translate (0, 0, MagicSpeed);
		if (timeM > 1)Destroy(gameObject);
	}
}
