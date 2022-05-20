using UnityEngine;
using System.Collections;

public class GoLv1 : MonoBehaviour 
{
	// Use this for initialization
	void Start (){}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) 
		{
			Application.LoadLevel ("Fairy Liar Lv1 - Rock");
		}
	}
}
