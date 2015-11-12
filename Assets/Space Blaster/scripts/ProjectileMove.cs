using UnityEngine;
using System.Collections;

public class ProjectileMove : MonoBehaviour {

	public float maxSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (maxSpeed * Time.deltaTime, 0, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;
	}
}
