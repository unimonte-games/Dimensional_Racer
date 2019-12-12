using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class PhotonPlayer : MonoBehaviour
{
    public GameObject myAvatar;
    private PhotonView PV;


    void Awake()
    {


        

        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            //myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonAvatar"), GameSetupController.GS.spawnPoints[spawnPicker].position, GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);

        }
    }
}



    

