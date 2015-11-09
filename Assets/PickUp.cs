using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public GameObject weaponPrefab;

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D col) 
	{
		Debug.Log (col.transform.GetChild(0).name);
		//GameObject hand = (GameObject) col.transform.GetChild(0);
		GameObject gun = (GameObject) Instantiate (weaponPrefab, col.transform.GetChild(0).transform.position, col.transform.rotation);
		gun.transform.parent = col.transform;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
