using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	
	public bool isJumping = false;
    public string movementAxis;
    public string jumpButton;
    public string shootButton;

	float jumpTime, jumpDelay = .5f;

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

        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis(movementAxis)));

        

		//	move left
		if(Input.GetAxisRaw(movementAxis) > 0)
		{
			transform.Translate(Vector2.right * 7f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
        //	move right
        if (Input.GetAxisRaw(movementAxis) < 0)
        {
			transform.Translate(Vector2.right * 7f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
		if(Input.GetButtonDown(jumpButton) && !isJumping)
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 260f);
			isJumping = true;
			jumpTime = jumpDelay;
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

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.tag == "Ground") {
			isJumping = false;
			anim.SetBool("jump", false);
			anim.SetBool("land", true);
		}
	}
}
