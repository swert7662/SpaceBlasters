using UnityEngine;
using System.Collections;

public class startLevel : MonoBehaviour {

	GameObject[] spawn;
	public GameObject[] playerPrefab;
	GameObject[] players;

	// Use this for initialization
	void Awake () {
		players = new GameObject[optionsMenu.players];
        spawn = GameObject.FindGameObjectsWithTag("Respawn");
        for (int i = 0; i < optionsMenu.players; i++)
		{
			players[i] = (GameObject) Instantiate(playerPrefab[i], spawn[i].transform.position, spawn[i].transform.rotation);
			players[i].GetComponent<player>().lives = optionsMenu.livesOrTime;
        }
	}
}
