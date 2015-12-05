using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
	
	public bool isJumping = false;
    public string movementAxis;
    public string jumpButton;
    public string shootButton;

	float jumpTime, jumpDelay = 2f;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	 void Update()
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

		if((Input.GetButtonDown(jumpButton) || ((GetComponent<player>().playerNum == 2 || GetComponent<player>().playerNum == 3) && Input.GetAxisRaw(jumpButton) > 0)) && !isJumping && Time.time > jumpTime)
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 260f);
			isJumping = true;
			jumpTime = Time.time + 1 / jumpDelay;
			anim.SetBool("jump", true);
			anim.SetBool("land", false);
		}
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

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            isJumping = true;
            anim.SetBool("jump", true);
            anim.SetBool("land", false);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("land", true);
        }
    }
}
