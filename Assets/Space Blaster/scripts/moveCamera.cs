using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x >= 42)
        {
            transform.position = new Vector3(1, transform.position.y, transform.position.z); ;
        }
	}
}
