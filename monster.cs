using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {

	private bool facingRight = false;
	public int far;

	public GameObject player;
	public GameObject Magic;
	private GameObject MagicClone;

	private float time;
	public float MagicInterval = 2f;
	public float move = 0.1f;
	public int Attackpower;
	public int HP;

	// Use this for initialization
	void Start () {}

	void OnTriggerEnter(Collider Magic) //自定義碰撞事件
	{    
		if (Magic.gameObject.tag == "Magic") //碰撞事件的物件標籤名稱是
		{    
			if (facingRight == true)transform.Translate (Vector3.left * 1);
			if (facingRight == false)transform.Translate (Vector3.right * 1);
			HP = HP - 10;
			Destroy(Magic.gameObject); //刪除碰撞到的物件
		}


		if (Magic.gameObject.tag == "Fire") 
		{    
			if (facingRight == false)transform.Translate (Vector3.right*5);
			HP = HP - 100;
			Destroy(Magic.gameObject); 
		}
	}

	// Update is called once per frame
	void Update ()
	{
		time = time + Time.deltaTime;
		if (Vector3.Distance (transform.position, player.transform.position) <= 15 && Vector3.Distance (transform.position, player.transform.position) > far)
		{	

			if (this.transform.position.x > player.transform.position.x)
			{
				if (facingRight == true){Flip ();}
				transform.Translate (Vector3.left * Time.deltaTime * 1);
			} else if (this.transform.position.x < player.transform.position.x)
			{	
				if (facingRight == false) {Flip ();}
				transform.Translate (Vector3.left * Time.deltaTime * 1);
			}

			if (Vector3.Distance (transform.position, player.transform.position) <= 10 && time > MagicInterval)
			{
				if (facingRight == true)
				{
					Vector3 pos = new Vector3 (transform.position.x+far, transform.position.y, transform.position.z);
					MagicClone = (GameObject)Instantiate (Magic, pos, transform.rotation);
					MagicClone.AddComponent <Magic0>();
					time = 0;
				}
				if (facingRight == false)
				{
					Vector3 pos = new Vector3 (transform.position.x-far, 2, transform.position.z);
					MagicClone = (GameObject)Instantiate (Magic, pos, transform.rotation);
					MagicClone.AddComponent <Magic0>();
					time = 0;
				}
			}
		}

		if (HP <= 0){Destroy (gameObject);}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x = theScale.x * -1;
		transform.localScale = theScale;
	}
}
