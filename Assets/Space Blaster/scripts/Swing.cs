using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	public GameObject AreaOfEffect;
	public float attackSpeed = 1;
	private Transform swingArea;
	private float timeToSwing = 0;

	// Use this for initialization
	void Start () {
		swingArea = transform.FindChild ("Swing Area");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > timeToSwing){
			timeToSwing = Time.time + 1/attackSpeed;
			gameObject.GetComponent<Animator>().Play("swing");
			GetComponent<AudioSource>().Play();
			swing();
		}
	}

	void swing()
	{
		GameObject swing = (GameObject)Instantiate (AreaOfEffect, swingArea.position, swingArea.rotation);
		swing.GetComponent<projectileDamage> ().shooter = this.gameObject.transform.parent;
	}
}
