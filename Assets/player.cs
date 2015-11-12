using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	
	public int health = 3;
	public int playerNumber = 1;
	public Transform shooter;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) 
	{
		// prevent player from shooting self
		// yields NullReferenceError when col is a powerup/weapon
		if (col.GetComponent<projectileDamage>().shooter != this.transform) 
		{
			// prevents collision with powerup/weapon from doing damage
			// incomplete method... think of something more efficient
			if (col.transform.name == "red photon(Clone)")
			{
				health--;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
		{
			die();
		}
	}
	
	void die()
	{
		Destroy (gameObject);
	}
}
