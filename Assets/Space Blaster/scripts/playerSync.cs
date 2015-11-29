using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerSync : NetworkBehaviour {

    [SyncVar]
    private Vector2 syncPos;

    [SyncVar]
    private Vector2 syncEulerAngles;

    [SerializeField]
    Transform myTrans;

    [SerializeField]
    float lerpRate = 15f;
    
    void FixedUpdate()
    {
        transmitPos();
        transmitRot();
        lerpPosition();
    }

    void lerpPosition()
    {
        if (!isLocalPlayer)
        {
            myTrans.position = Vector2.Lerp(myTrans.position, syncPos, Time.deltaTime * lerpRate);
            myTrans.eulerAngles = Vector2.Lerp(myTrans.eulerAngles, syncEulerAngles, Time.deltaTime * lerpRate * 20);
        }
    }

    [Command]
    void CmdProvidePositionToServer(Vector2 pos)
    {
        syncPos = pos;
    }

    [Command]
    void CmdProvideRotationToServer(Vector2 eulerAngles)
    {
        if (gameObject.transform.name == "Pink Alien(Clone)")
        {
            Debug.Log(eulerAngles);
            Debug.Log(syncEulerAngles);
        }
        
        syncEulerAngles = eulerAngles;
    }

    [ClientCallback]
    void transmitRot()
    {
        if (isLocalPlayer)
        {
            CmdProvideRotationToServer(myTrans.eulerAngles);
        }
    }

    [ClientCallback]
    void transmitPos()
    {
        if (isLocalPlayer)
        {
            CmdProvidePositionToServer(myTrans.position);
        }
    }


}
