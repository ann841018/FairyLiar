using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public bool facingRight = true;
	public bool grounded = true;

	Rigidbody myRigidbody;
	Animator myAnim;

	public float mySpeed = 3.0f;
	public float jumpForce;

	public GameObject Magic;
	public GameObject Fire;
	public GameObject fire;
	private GameObject MagicClone;
	private float time;
	public float MagicInterval = 0.5f;

	public int HP;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = this.gameObject.GetComponent<Rigidbody>();
		myAnim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (grounded && (Input.GetKeyDown (KeyCode.W))) {myRigidbody.AddForce (new Vector3 (0.0f, jumpForce));}

		if (Input.GetKeyDown (KeyCode.S)){myRigidbody.AddForce (new Vector3 (0.0f, -1*jumpForce));}
		bool go = (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D));
		myAnim.SetBool ("go", go);

		if (Input.GetKey(KeyCode.A))
		{
			myRigidbody.velocity = new Vector3 (-1*mySpeed, myRigidbody.velocity.y);
			if (facingRight == true)
			{
				transform.Rotate (new Vector3 (0, 180, 0));
				facingRight = false;
			}
		}

		if (Input.GetKey(KeyCode.D))
		{
			myRigidbody.velocity = new Vector3 (mySpeed, myRigidbody.velocity.y);
			if (facingRight == false) 
			{
				transform.Rotate (new Vector3 (0, -180, 0));
				facingRight = true;
			}
		}

		time = time + Time.deltaTime;
		bool attack = Input.GetKeyDown (KeyCode.Space);
		myAnim.SetBool ("attack", attack);

		if (Input.GetKeyDown (KeyCode.Space) && time > MagicInterval)
		{
			if(facingRight==true)
			{
				Vector3 pos = new Vector3 (transform.position.x+1, transform.position.y+1f, transform.position.z);
				MagicClone = (GameObject)Instantiate (Magic, pos, transform.rotation);
			}
			else if(facingRight==false)
			{
				Vector3 pos = new Vector3 (transform.position.x-1, transform.position.y+1f, transform.position.z);
				MagicClone = (GameObject)Instantiate (Magic, pos, transform.rotation);
			}

			MagicClone.AddComponent <Magic>();
			time = 0;
		}

		if (Input.GetKey (KeyCode.P)) {mySpeed = 10.0f;}

		if (Input.GetKeyDown (KeyCode.O)) 
		{
			Vector3 pos = new Vector3 (transform.position.x, transform.position.y+9, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos1 = new Vector3 (transform.position.x-6, transform.position.y+10, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos1, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos2 = new Vector3 (transform.position.x-4, transform.position.y+8, transform.position.z);MagicClone = (GameObject)Instantiate (fire, pos2, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos3 = new Vector3 (transform.position.x-2, transform.position.y+10, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos3, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos4 = new Vector3 (transform.position.x, transform.position.y+7, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos4, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos5 = new Vector3 (transform.position.x+2, transform.position.y+10, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos5, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos6 = new Vector3 (transform.position.x+4, transform.position.y+14, transform.position.z);MagicClone = (GameObject)Instantiate (fire, pos6, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos7 = new Vector3 (transform.position.x+6, transform.position.y+10, transform.position.z);MagicClone = (GameObject)Instantiate (fire, pos7, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos8 = new Vector3 (transform.position.x+8, transform.position.y+13, transform.position.z);MagicClone = (GameObject)Instantiate (Fire, pos8, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos9 = new Vector3 (transform.position.x+10, transform.position.y+10, transform.position.z);MagicClone = (GameObject)Instantiate (fire, pos9, transform.rotation);MagicClone.AddComponent <Fire>();
			Vector3 pos10 = new Vector3 (transform.position.x, transform.position.y+11, transform.position.z);MagicClone = (GameObject)Instantiate (fire, pos10, transform.rotation);MagicClone.AddComponent <Fire>();
		}
	}

	void OnTriggerEnter(Collider other)
	{    
		if (other.gameObject.tag == "Ground") {grounded = true;}
		if (other.gameObject.tag == "Rock") {HP = HP - 10;}
		if (other.gameObject.tag == "Lion") {HP = HP - 30;}
		if (other.gameObject.tag == "Projector") {HP = HP - 50;}
		if (other.gameObject.tag == "Boss") {HP = HP - 100;}
		if (other.gameObject.tag == "Biscuit") {HP = HP - 1;}
		if (other.gameObject.tag == "monsterAttack"){HP = HP - 10;Destroy(other.gameObject);}
		if (HP <= 0) {Destroy(this.gameObject);}
	}
	void OnTriggerExit(Collider other){if (other.gameObject.tag == "Ground"){grounded = false;}}
}
