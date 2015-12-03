using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public float fireRate = 0;
	public GameObject projectilePrefab;
	public Transform firePoint;

    private string shootButton;
	private float timeToFire = 0;

	// Use this for initialization
	void Start () 
	{
		firePoint = transform.FindChild ("firePoint");
        shootButton = GetComponentInParent<playerMove>().shootButton;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetButton(shootButton) && gameObject.transform.name == "Force Gun Equipped(Clone)" && Time.time > timeToFire)
        {
            GetComponent<AudioSource>().Play();
            timeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}
		else if (Input.GetButtonDown(shootButton) && Time.time > timeToFire)
        {
            GetComponent<AudioSource>().Play();
            timeToFire = Time.time + 1 / fireRate;
			Shoot ();
		}

	}

	void Shoot()
	{
		if (transform.name == "Shotgun Equipped(Clone)")
        {
			GameObject bullet1 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet1.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
			GameObject bullet2 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet2.transform.Rotate (Vector3.forward * -10);
			bullet2.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
			GameObject bullet3 = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet3.transform.Rotate (Vector3.forward * 10);
			bullet3.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;

		}
        else
        {
			GameObject bullet = (GameObject)Instantiate (projectilePrefab, firePoint.position, firePoint.rotation);
			bullet.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
		}
	}

}
