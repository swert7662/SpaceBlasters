using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {

	public float attackSpeed = 1;
	private float timeToSwing = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > timeToSwing){
			timeToSwing = Time.time + 1/attackSpeed;
			gameObject.GetComponent<Animator>().Play("swing");
			GetComponent<AudioSource>().Play();



		}
	}
}
