using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerNetworking : NetworkBehaviour {

	[SerializeField] Behaviour[] componentsToDisable;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer) 
		{
			for (int i  = 0; i < componentsToDisable.Length; i++)
			{
				componentsToDisable[i].enabled = false;
			}
		}
	}
}
