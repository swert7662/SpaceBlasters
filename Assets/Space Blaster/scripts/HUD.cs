using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites; 
	public Sprite[] HUD_sprites;
	public Sprite[] numSprites;

	public player[] player;
	public Transform[] heartsLocation;
	public GameObject heartsPrefab;
	public GameObject parent;
	
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
			heartUI[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = HUD_sprites[HUDsprite(i)];
			heartUI[i].transform.GetChild(0).gameObject.AddComponent<SpriteRenderer>();
			heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().lives];
		}
	}

	int HUDsprite(int i)
	{
		if (player[i].transform.name == "Green Alien") {
			return 0;
		}
		else if (player[i].transform.name == "Blue Alien"){
			return 1;
		}
		else if (player[i].transform.name == "Pink Alien"){
			return 2;
		}
		return 0;
	}

	void Update()
	{
		for (int i = 0; i < heartUI.Length; i++) 
		{
			if (player[i])
			{
				heartUI_images[i].sprite = heartSprites [player[i].health];
				heartUI[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = numSprites[player[i].GetComponent<player>().lives];
			}
		}
	}

}
