using UnityEngine;
using System.Collections;
using System;

public class optionsMenu : MonoBehaviour {

	public GameObject choiceHolder;

	public void Start()
	{
	}

	public void gameModeSelect()
	{
		if (GetComponentInChildren<UnityEngine.UI.Text> ().text == "Stock") {
			choiceHolder.GetComponent<gameModeVars> ().gameMode = "Stock";
		}
		else if (GetComponentInChildren<UnityEngine.UI.Text> ().text == "Time") {
			Debug.Log ("Time");
			choiceHolder.GetComponent<gameModeVars> ().gameMode = "Time";
		}
	}

	public void timeSelect()
	{
		UnityEngine.UI.Text[] options = GetComponentsInChildren<UnityEngine.UI.Text> ();
		choiceHolder.GetComponent<gameModeVars> ().num = Int32.Parse (options[1].text);
	}

	public void back()
	{
		Application.LoadLevel ("Title Menu");
	}
}
