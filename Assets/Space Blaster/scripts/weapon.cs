using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;
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

		if (Input.GetButtonDown("Fire1") && Time.time > timeToFire) {
			timeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}

	}

	void Shoot()
	{
		//	creates the projectile
		GameObject bullet = (GameObject) Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
		bullet.GetComponent<projectileDamage>().shooter = this.gameObject.transform.parent;
	}

}
