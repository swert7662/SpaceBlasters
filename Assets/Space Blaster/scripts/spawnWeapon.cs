using UnityEngine;
using System.Collections;

public class spawnWeapon : MonoBehaviour {

	public float timer;
	public GameObject[] weapons;
	private float saveTimer;

	void Start(){
		saveTimer = timer;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Debug.Log ("DING");
			timer = saveTimer;
			createWeapon();
		}
	}

	void createWeapon(){
		if (transform.childCount == 0) {
			GameObject gun = (GameObject) Instantiate (weapons [2], transform.position, transform.rotation);
			gun.transform.parent = transform;
		}
	}

}
