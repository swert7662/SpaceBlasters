using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public int lives = 1;
	public int playerNum;
	public int health = 3;
	public int playerNumber = 1;
	public GameObject[] respawn;
	//public Transform shooter;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) {
		projectileDamage P = col.GetComponent<projectileDamage> ();
		// prevent player from shooting self
		// yields NullReferenceError when col is a powerup/weapon
		if (P != null && P.shooter != this.transform) {
			// prevents collision with powerup/weapon from doing damage
			// incomplete method... think of something more efficient
			if (col.transform.name == "red photon(Clone)") {
				health -= 3;
			} else if (col.transform.name == "green laser(Clone)") {
				health -= 1;
			}
			else if (col.transform.name == "Lightsaber Swing(Clone)") {
				health -= 3;
			}
		} 
	}
	public void Start()
	{
		respawn = GameObject.FindGameObjectsWithTag ("Respawn");
	}

	public void kill(){
		health = 0;
		die();
	}
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0){
			die();
		}
	}
	
	void die() {
		if (lives > 0) {
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			if (rb == null) {
				Debug.LogError ("Unable to acquire Rigidbody2D for player");
				Application.Quit ();
			}
			lives -= 1; 
			health = 3;

			Debug.Log (respawn.Length);
			//Debug.Log(respawn[1].transform.position);
			transform.position = respawn[playerNum].transform.position;
		} 
		else 
		{
			Destroy(gameObject);
		}
	}
}
