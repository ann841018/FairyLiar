using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float MagicSpeed = 0.05f;
	public int Magicpower = 100;
	private float timeM;

	// Use this for initialization
	void Start () {}

	// Update is called once per frame
	void Update ()
	{
		timeM = timeM + Time.deltaTime;
		transform.Translate (0, -2*MagicSpeed,MagicSpeed );
		if (timeM > 1.5f)Destroy(gameObject);
	}
}
