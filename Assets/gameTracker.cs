using UnityEngine;
using System.Collections;

public class gameTracker : MonoBehaviour {

    static public int playersDead = 0;
    static public int winner = 1;

    private float winDelay = 2;

    bool roundOver()
    {
        return playersDead == optionsMenu.players-1 ? true : false;
    }

    void Update()
    {
        if(roundOver())
        {
            winDelay -= Time.deltaTime;
            if (winDelay <= 0)
            {
                winner = GameObject.FindGameObjectWithTag("Player").GetComponent<player>().playerNum;
                Application.LoadLevel("Win Screen");
            }
        }
    }
}
