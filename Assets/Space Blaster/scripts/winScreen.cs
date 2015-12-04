using UnityEngine;
using System.Collections;

public class winScreen : MonoBehaviour {

    public UnityEngine.UI.Text winMessage;

	void Start ()
    {
        winMessage.text = "Player " + (gameTracker.winner + 1).ToString() + " is Victorious!!!!";
	}

    public void back()
    {
        GetComponentInChildren<AudioSource>().Play();
        Application.LoadLevel("Title Menu");
    }

}
