using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public float fireRate = 0;
	public GameObject projectilePrefab;
	public LayerMask notToHit;
	public Transform firePoint;

	float timeToFire = 0;

	// Use this for initialization
	void Awake () 
	{
		firePoint = transform.FindChild ("firePoint");

		if (firePoint == null) 
		{
			Debug.LogError("No firePoint? WHAT?!");
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameObject.transform.parent.name == "Green Alien(Clone)") {
			if (Input.GetButton ("Fire1") && gameObject.transform.name == "Force Gun Equipped(Clone)" && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			} else if (Input.GetButtonDown ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
		else {
			if (Input.GetButton ("Fire2") && gameObject.transform.name == "Force Gun Equipped(Clone)" && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			} else if (Input.GetButtonDown ("Fire2") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}


	}

	void Shoot()
	{
		if (transform.name == "Shotgun Equipped(Clone)") {
			GetComponent<AudioSource>().Play();
			GameObject bullet1 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet1.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
			GameObject bullet2 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet2.transform.Rotate (Vector3.forward * -10);
			bullet2.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
			GameObject bullet3 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet3.transform.Rotate (Vector3.forward * 10);
			bullet3.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;

		} else {
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
		}
	}

}
