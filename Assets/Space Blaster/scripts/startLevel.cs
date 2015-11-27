using UnityEngine;
using System.Collections;

public class startLevel : MonoBehaviour {

	public GameObject[] spawn;
	public GameObject[] playerPrefab;
	public GameObject[] players;


	// Use this for initialization
	void Awake () {
		players = new GameObject[4];
		for (int i = 0; i < spawn.Length; i++)
		{
			players[i] = (GameObject) Instantiate(playerPrefab[i], spawn[i].transform.position, spawn[i].transform.rotation);
			players[i].GetComponent<player>().lives = optionsMenu.livesOrTime;
		}
	}
}
