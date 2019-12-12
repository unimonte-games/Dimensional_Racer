using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SetAnimation : MonoBehaviour
{

    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        
        

        if (PV.IsMine)
        {
            
        }

    }
}
