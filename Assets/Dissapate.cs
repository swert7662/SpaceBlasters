using UnityEngine;
using System.Collections;

public class Dissapate : MonoBehaviour {

	public float lifeSpan = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifeSpan -= Time.deltaTime;
		Debug.Log ("Test");
		if (lifeSpan <= 0) 
		{
			Destroy(gameObject);
		}

	}
}
