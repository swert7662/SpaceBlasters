using UnityEngine;
using System.Collections;

public class damageHandler : MonoBehaviour {

	public int health = 1;
	public Transform shooter;
	public GameObject explosionPrefab;

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) 
	{
		if (shooter != col.transform) {
			health--;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (health <= 0)
		{
			if (gameObject.name == "red photon(Clone)")
			{
				GameObject explosion = (GameObject) Instantiate (explosionPrefab, transform.position, transform.rotation);
			}
			die();
		}
	}

	void die()
	{
		Destroy (gameObject);

	}

	IEnumerator photonExplode()
	{
		GameObject explosion = (GameObject) Instantiate (explosionPrefab, transform.position, transform.rotation);

		yield return new WaitForSeconds (2);
		Debug.Log ("test");
		Destroy (explosion);
	}
	
	
}
