using UnityEngine;
using System.Collections;

public class startLevel : MonoBehaviour {

	public GameObject[] spawn;
	public GameObject[] playerPrefab;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < spawn.Length; i++)
		{
			Instantiate(playerPrefab[i], spawn[i].transform.position, spawn[i].transform.rotation);
		}
	}
}
