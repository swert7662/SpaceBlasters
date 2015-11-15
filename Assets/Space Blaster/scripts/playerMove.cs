using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	
	public bool isJumping = false;

	float jumpTime, jumpDelay = .5f;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();
	}

	void Movement()
	{
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

		//	same as GetKey(KeyCode.D)
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		//	same as GetKey(KeyCode.A)
		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * 4f * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.W) && !isJumping)
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 200f);
			isJumping = true;
			jumpTime = jumpDelay;
			anim.SetBool("jump", true);
			anim.SetBool("land", false);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
			isJumping = false;
			anim.SetBool("jump", false);
			anim.SetBool("land", true);
		}
		if (col.gameObject.tag == "Respawn") {
			this.GetComponent<player>().kill();
			Debug.Log("Respawn");
		}
	}
}
