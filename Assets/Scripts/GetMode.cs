using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class GetMode : MonoBehaviour
    {
        public PhotonView PV;

        public void Start()
        {
            PV.RPC("Victory", RpcTarget.AllBufferedViaServer);
        }
        
        [PunRPC]
        public void Victory()
        {
            GameObject V = PhotonNetwork.Instantiate("VictoryOrDefeat", transform.position, transform.rotation, 0);
        }
    }
}
