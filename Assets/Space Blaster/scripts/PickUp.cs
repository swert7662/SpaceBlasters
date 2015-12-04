using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public GameObject weaponPrefab;

	void OnTriggerEnter2D (Collider2D col) 
	{
		// if col is a player
		if (col.transform.childCount > 0)
        {
			alreadyEquipped (col.transform);
			GameObject gun = (GameObject)Instantiate (weaponPrefab, col.transform.GetChild(0).transform.position, col.transform.rotation);
			if (gun.transform.GetChild(0).name == "Hilt")
			{
				gun.transform.localPosition = new Vector3(gun.transform.position.x, gun.transform.position.y+0.5f, gun.transform.position.z);
			}
			gun.transform.parent = col.transform;
			Destroy (gameObject);
		}
	}

	// destroys the previously equipped weapon
	void alreadyEquipped (Transform shooter)
	{
		if (shooter.childCount > 1) {
			Destroy (shooter.GetChild(1).gameObject);
		}
	}

}
