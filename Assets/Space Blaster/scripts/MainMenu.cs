using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void startGame()
	{
		Application.LoadLevel ("Level Selection");
	}

	public void exitGame()
	{
		Application.Quit ();
	}
}
