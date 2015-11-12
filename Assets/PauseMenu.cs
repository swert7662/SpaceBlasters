using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject menuUI;
	private bool menuUp = false;

	void Start()
	{
		menuUI.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetButtonDown("Menu"))
		{
			Debug.Log("TEST");
			menuUp = !menuUp;
		}

		if (menuUp) 
		{
			menuUI.SetActive(true);
			Time.timeScale = 0;
		}

		if (!menuUp) 
		{
			menuUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void resume()
	{
		menuUp = false;
	}

	public void exitGame()
	{
		Application.Quit ();
	}

}
