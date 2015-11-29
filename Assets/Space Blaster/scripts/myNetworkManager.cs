using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class myNetworkManager : NetworkManager {

    public GameObject spawn;
    public GameObject startWeapon;
    private int players = 0;

   public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject temp = (GameObject) Instantiate(spawnPrefabs[players], spawn.transform.position, spawn.transform.rotation);
        GameObject gun = (GameObject)Instantiate(startWeapon, temp.transform.GetChild(0).transform.position, temp.transform.rotation);
        gun.transform.parent = temp.transform;
        NetworkServer.AddPlayerForConnection(conn, temp, playerControllerId);
        players += 1;
    }

}
