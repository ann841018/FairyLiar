using UnityEngine;
using System.Collections;

public class GoLv3 : MonoBehaviour 
{
	// Use this for initialization
	void Start ()
	{
	}

	void OnTriggerStay(Collider col)
	{
		if (col.name == "player") 
		{
			if (Input.GetKey(KeyCode.S))
				Application.LoadLevel ("Fairy Liar Lv3 - Projector");
		}
	}

	// Update is called once per frame
	void Update ()
	{
	}
}
