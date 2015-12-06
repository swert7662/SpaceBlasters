using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites; 
	public Sprite[] HUD_sprites;
	public Sprite[] numSprites;
	public player[] player;
	public Transform[] heartsLocation;
	public GameObject heartsPrefab;
	public GameObject parent;
    public Text timer;
	
	GameObject[] heartUI;
	Image[] heartUI_images;

	void Start()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("Player");
		player = new player[temp.Length];
		heartUI = new GameObject[temp.Length];
		heartUI_images = new Image[temp.Length];

		for (int i = 0; i < temp.Length; i++) 
		{
			player[i] = temp[i].GetComponent<player>();
			heartUI[i] = (GameObject) Instantiate (heartsPrefab, heartsLocation[i].position, heartsLocation[i].rotation);
			heartUI[i].transform.parent = parent.transform;
			heartUI_images[i] = heartUI[i].GetComponent<Image>();
			heartUI[i].transform.GetChild(1).gameObject.AddComponent<SpriteRenderer>();
			heartUI[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = HUD_sprites[player[i].GetComponent<player>().playerNum];
			heartUI[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "HUD";
			heartUI[i].transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>();
			heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().lives];
            heartUI[i].transform.GetChild(2).gameObject.AddComponent<SpriteRenderer>();
        }
        if (optionsMenu.gameMode == "Stock")
        {
            Destroy(timer);
        }
	}

	void Update()
	{
		for (int i = 0; i < heartUI.Length; i++) 
		{
			if (player[i])
			{
				heartUI_images[i].sprite = heartSprites [player[i].health];
                if (optionsMenu.gameMode == "Stock")
                {
                    heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().lives];
                }
                else
                {
                    drawKills(i);
                }
                heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "HUD";
            }
		}
        if (optionsMenu.gameMode == "Time")
        {
           timer.text = parseTime(GetComponent<gameTracker>().time);
        }
	}

    private void drawKills(int i)
    {
        if (player[i].GetComponent<player>().kills < 10)
        {
            heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().kills];
        }
        else
        {
            heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().kills / 10];
            heartUI[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().kills % 10];
            heartUI[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "HUD";
        }
    }

    private string parseTime(float f)
    {
        String secondsString;
        int minutes = (int)f / 60;
        int seconds = (int)(((f / 60) - minutes) * 60);

        secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

        return minutes + ":" + secondsString;
    }
}
