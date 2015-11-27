using UnityEngine;
using System.Collections;
using System;

public class optionsMenu : MonoBehaviour {

	static public int livesOrTime = 1;
	static public string gameMode = "Stock";
	
	public void gameModeSelect()
	{
		GetComponent<AudioSource>().Play();
		if (GetComponentInChildren<UnityEngine.UI.Text> ().text == "Stock") {
			gameMode = "Stock";
		}
		else if (GetComponentInChildren<UnityEngine.UI.Text> ().text == "Time") {
			Debug.Log ("Time");
			gameMode = "Time";
		}
	}

	public void timeSelect()
	{
		GetComponent<AudioSource>().Play();
		UnityEngine.UI.Text[] options = GetComponentsInChildren<UnityEngine.UI.Text> ();
		livesOrTime = Int32.Parse (options[1].text);
	}

	public void back()
	{
		GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Title Menu");
	}
}
