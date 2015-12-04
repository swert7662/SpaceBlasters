using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public int lives = 1;
	public int health = 3;
	public GameObject[] respawn;
    public int playerNum;
    public int kills = 0;

    // Use this for initialization
    public void Start()
    {
        respawn = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		projectileDamage P = col.GetComponent<projectileDamage> ();
		if (col.tag == "Instant Death")
        {
			health = 0;
		}
		else if (P != null && P.shooter != this.transform)
        {
            takeDamage(col.GetComponent<projectileDamage>().damage);
            if (health <= 0)
            {
                col.GetComponent<projectileDamage>().shooter.GetComponent<player>().kills += 1;
            }
        }
	}
	
	void kill(){
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
		if (lives > 0)
        {
			lives -= 1; 
			health = 3;
			transform.position = respawn[playerNum].transform.position;
		} 
		else 
		{
            gameTracker.playersDead += 1;
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
