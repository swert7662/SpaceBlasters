using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public void startGame()
	{
		Application.LoadLevel (startLevel);
	}

	public void exitGame()
	{
		Application.Quit ();
	}
}
