using UnityEngine;
using System.Collections;

public class GoLv2 : MonoBehaviour 
{
	// Use this for initialization
	void Start (){}

	void OnTriggerStay(Collider col)
	{
		if (col.name == "player") 
		{
			if (Input.GetKey(KeyCode.S))
				Application.LoadLevel ("Fairy Liar Lv2 - Lion");
		}
	}

	// Update is called once per frame
	void Update (){}
}
