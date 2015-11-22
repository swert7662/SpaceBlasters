using UnityEngine;
using System.Collections;

public class spawnWeapon : MonoBehaviour {

	public float timer;
	public GameObject[] weapons;
	private float saveTimer;
	private int randNum;

	void Start(){
		saveTimer = timer;
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = saveTimer;
			createWeapon();
		}
	}
	// 10% Ion Cannon
	// 30% Force Gun
	// 30% Sword
	// 30% shotgun
	void createWeapon(){
		if (transform.childCount == 0) {
			randNum = (int)(Random.Range(1,100));
			if (randNum < 11)
			{
				GameObject spawn = (GameObject) Instantiate (weapons [1], transform.position, transform.rotation);
				spawn.transform.parent = transform;
			}
			else if (randNum > 10 && randNum < 41)
			{
				GameObject spawn = (GameObject) Instantiate (weapons [2], transform.position, transform.rotation);
				spawn.transform.parent = transform;	
			}
			else if (randNum > 40 && randNum < 71)
			{
				GameObject spawn = (GameObject) Instantiate (weapons [0], transform.position, transform.rotation);
				spawn.transform.parent = transform;	
			}
			else if (randNum > 70)
			{
				GameObject spawn = (GameObject) Instantiate (weapons [3], transform.position, transform.rotation);
				spawn.transform.parent = transform;	
			}
		}
	}

}
