using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class playerMove : MonoBehaviour {
	
	public bool isJumping = false;
	public float jumpHeight = 250f;
	
	float jumpTime = 0f, jumpDelay = 2f;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		bool cont = true;
		if(cont)  cont = amIAlive();
		if (cont) cont = Movement();
	}

	bool amIAlive(){
		player P = GetComponent<player> ();
		bool ret = true;
		if (P.health <= 0 && P.lives <= 0) {
			ret = false;
		}
		return ret;
	}

	bool Movement()
	{
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

		//	same as GetKey(KeyCode.D)
		if(Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector2.right * 7f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
        //	same as GetKey(KeyCode.A)
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * 7f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
		if(Input.GetKeyDown(KeyCode.W) && !isJumping && Time.time > jumpTime)
		{
			GetComponent<Rigidbody2D>().AddForce (new Vector3(0, jumpHeight, 0), ForceMode2D.Force);
			isJumping = true;
			jumpTime = Time.time + 1/jumpDelay;
			anim.SetBool("jump", true);
			anim.SetBool("land", false);
		}

		return true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
		{
			isJumping = false;
			anim.SetBool("jump", false);
			anim.SetBool("land", true);
		}
	}

	/*void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.tag == "Ground") {
			isJumping = false;
			anim.SetBool("jump", false);
			anim.SetBool("land", true);
		}
	}*/
}
