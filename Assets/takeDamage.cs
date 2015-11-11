using UnityEngine;
using System.Collections;

public class takeDamage : MonoBehaviour {

	public int health = 1;
	public Transform shooter;
	public GameObject explosionPrefab;
	
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.GetComponent<projectileDamage>().shooter != this.transform && col.transform.name == "red photon(Clone)") {
			health--;
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
