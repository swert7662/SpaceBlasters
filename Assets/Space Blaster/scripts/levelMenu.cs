using UnityEngine;
using System.Collections;

public class levelMenu : MonoBehaviour {

	public void forest()
	{
		Application.LoadLevel ("forest");
	}
	
	public void lava()
	{
		Application.LoadLevel ("Lava");
	}

	public void space()
	{
		Application.LoadLevel ("Space");
	}
}
