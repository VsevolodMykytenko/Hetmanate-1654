using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    void Update()
    {
        testsync();
    }
    
    public void testsync()
    { 
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("OnMouseDown", RpcTarget.All);
    }
    [PunRPC]
    
    void OnMouseDown() 
    {
        
    }
}
