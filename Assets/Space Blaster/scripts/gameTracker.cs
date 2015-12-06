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
            return playersDead >= optionsMenu.players - 1 ? true : false;
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
            if (optionsMenu.gameMode == "Stock" && winDelay == 2f)
            {
                winner = lastAlive();
            }
            else if (winDelay == 2)
            {
                winner = mostKills();
            }

            winDelay -= Time.deltaTime;
            if (winDelay <= 0)
            {
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

    private int lastAlive()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<player>().lives > 0)
            {
                return players[i].GetComponent<player>().playerNum;
            }
        }
        return -1;
    }

    private int mostKills()
    {
        int mostKills = 0;
        int winner = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<player>().kills > mostKills)
            {
                mostKills = players[i].GetComponent<player>().kills;
                winner = i;
            }
        }
        return winner;
    }
}
