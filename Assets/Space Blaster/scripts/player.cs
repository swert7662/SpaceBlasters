using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public int lives = 1;
	public int health = 3;
	public GameObject[] respawn;
    public int respawnNum;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) {
		projectileDamage P = col.GetComponent<projectileDamage> ();
		if (col.tag == "Instant Death") {
			health = 0;
		}
		else if (P != null && P.shooter != this.transform) {
			if (col.transform.name == "red photon(Clone)") {
				takeDamage(3);
			} else if (col.transform.name == "green laser(Clone)") {
				takeDamage(1);
			}
			else if (col.transform.name == "Lightsaber Swing(Clone)") {
				takeDamage(3);
			}
			else if (col.transform.name == "Shotgun Shot(Clone)") {
				takeDamage(1);
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
			health = 0;
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
			transform.position = respawn[respawnNum].transform.position;
		} 
		else 
		{
			Destroy(gameObject);
		}
	}

	private void takeDamage(int dmg)
	{
		health -= dmg;
		if (health < 0) {
			health = 0;
		}
	}
}
