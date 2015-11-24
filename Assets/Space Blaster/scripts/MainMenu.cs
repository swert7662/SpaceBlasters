using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void startGame()
	{
		GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Level Selection");
	}

	public void options()
	{
		GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Options Menu");
	}


	public void exitGame()
	{
		GetComponent<AudioSource>().Play();
		Application.Quit ();
	}
}
