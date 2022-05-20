using UnityEngine;
using System.Collections;

public class GoBonus : MonoBehaviour 
{
	// Use this for initialization
	void Start (){}

	void OnTriggerStay(Collider col)
	{
		if (col.name == "player") 
		{
			if (Input.GetKey(KeyCode.S))
				Application.LoadLevel ("Fairy Liar Bonus - Biscuit monster");
		}
	}

	// Update is called once per frame
	void Update (){}
}
