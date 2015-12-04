using UnityEngine;
using System.Collections;

public class gameTracker : MonoBehaviour {

    static public int playersDead = 0;
    static public int winner = 1;
    public float time;


    private float winDelay = 2;
    
    void Start()
    {
        Debug.Log("start");
        time = optionsMenu.time;
    }

    bool roundOver()
    {
        if (optionsMenu.gameMode == "Stock")
        {
            return playersDead == optionsMenu.players - 1 ? true : false;
        }
        else
        {
            return time <= 0 ? true : false;
        }
    }

    void Update()
    {
        
        if(roundOver())
        {
            winDelay -= Time.deltaTime;
            if (winDelay <= 0)
            {
                winner = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().playerNum;
                playersDead = 0;
                time = optionsMenu.time;
                Application.LoadLevel("Win Screen");
            }
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
