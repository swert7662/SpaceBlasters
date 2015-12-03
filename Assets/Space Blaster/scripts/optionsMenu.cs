using UnityEngine;
using System.Collections;
using System;

public class optionsMenu : MonoBehaviour {

    static public int livesOrTime = 1;
    static public int players = 2;
	static public string gameMode = "Stock";

    public void Start()
    {
        for (int i = 0; i < GetComponentsInChildren<UnityEngine.UI.Text>().Length; i++)
        {
            if (GetComponentsInChildren<UnityEngine.UI.Text>()[i].text == "me")
            {
                Debug.Log(i);
            }
        }
    }

	public void timeSelect()
	{
        GetComponent<AudioSource>().Play();
        gameMode = "Time";
        GetComponentsInChildren<UnityEngine.UI.Text>()[6].text = "Time";
	}

    public void stockSelect()
    {
        GetComponent<AudioSource>().Play();
        gameMode = "Stock";
        GetComponentsInChildren<UnityEngine.UI.Text>()[6].text = "Stock";
    }

    //**************************
    //Players buttons
    //**************************

    public void players2()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = "2";
        players = 2;
    }
    public void players3()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = "3";
        players = 3;
    }
    public void players4()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[0].text = "4";
        players = 4;
    }

    //**************************
    //Lives buttons
    //**************************

    public void click1()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "1";
        livesOrTime = 1;
    }
    public void click2()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "2";
        livesOrTime = 2;
    }
    public void click3()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "3";
        livesOrTime = 3;
    }
    public void click4()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "4";
        livesOrTime = 4;
    }
    public void click5()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "5";
        livesOrTime = 5;
    }
    public void click6()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "6";
        livesOrTime = 6;
    }
    public void click7()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "7";
        livesOrTime = 7;
    }
    public void click8()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "8";
        livesOrTime = 8;
    }
    public void click9()
    {
        GetComponent<AudioSource>().Play();
        GetComponentsInChildren<UnityEngine.UI.Text>()[9].text = "9";
        livesOrTime = 9;
    }

    public void back()
	{
		GetComponent<AudioSource>().Play();
		Application.LoadLevel ("Title Menu");
	}
}
