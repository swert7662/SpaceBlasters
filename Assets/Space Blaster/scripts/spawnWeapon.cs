using UnityEngine;
using System.Collections;

public class spawnWeapon : MonoBehaviour {

	public float timer;
	public GameObject[] weapons;
	private float saveTimer;
	private int randNum;

	void Start(){
		createWeapon ();
		saveTimer = timer;
	}

	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = saveTimer;
                createWeapon();
            }
		}
	}
	// 10% Ion Cannon
	// 30% Force Gun
	// 30% Sword
	// 30% shotgun
	void createWeapon(){
        randNum = Random.Range(0, weapons.Length);
        GameObject spawn = (GameObject)Instantiate(weapons[randNum], transform.position, transform.rotation);
        Debug.Log(randNum);
        spawn.transform.parent = transform;
    }
}
