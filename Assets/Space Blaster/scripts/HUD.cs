using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] heartSprites;
	public Image[] heartUI_images;
	public GameObject[] heartUI;
	public player[] player;
	public Transform[] heartsLocation;
	public GameObject heartsPrefab;
	public GameObject parent;

	void Start()
	{
		GameObject[] temp = GameObject.FindGameObjectsWithTag ("Player");
		player = new player[temp.Length];
		heartUI = new GameObject[temp.Length];
		heartUI_images = new Image[temp.Length];
		for (int i = 0; i < temp.Length; i++) 
		{
			player[i] = temp[i].GetComponent<player>();
			Debug.Log (player[i].name);
			heartUI[i] = (GameObject) Instantiate (heartsPrefab, heartsLocation[i].position, heartsLocation[i].rotation);
			heartUI[i].transform.parent = parent.transform;
			heartUI_images[i] = heartUI[i].GetComponent<Image>();
		}


	}

	void Update()
	{
		for (int i = 0; i < heartUI.Length; i++) 
		{
			heartUI_images[i].sprite = heartSprites [player[i].health];
		}
	}

}
