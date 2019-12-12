using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
   
    [SerializeField]
    private int gameVersion;

   
    void Start() 
    {

        PhotonNetwork.GameVersion = gameVersion.ToString();
        PhotonNetwork.ConnectUsingSettings(); 
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Voce está Conectado ao " + PhotonNetwork.CloudRegion + " server!");
    }
}
