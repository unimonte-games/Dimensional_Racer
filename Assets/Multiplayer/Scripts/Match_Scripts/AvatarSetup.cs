using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace UnityStandardAssets.Characters.ThirdPerson {
    public class AvatarSetup : MonoBehaviourPunCallbacks
    {

        public static AvatarSetup AS;
        public GameObject myCharacter;
        public Transform[] spawnPoints;
        int spawnPicker;

        void Awake()
        {

            spawnPicker = Random.Range(0, spawnPoints.Length);

            GameObject myCharacter = PhotonNetwork.Instantiate(PlayerInfo.PI.mySelectedCharacter_Name,
                spawnPoints[spawnPicker].position, spawnPoints[spawnPicker].rotation, 0);

        }

    }
}