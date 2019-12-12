using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class GameRoomList : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject roomPanel; //display for when in room
        [SerializeField]
        private Transform playersContainer; //used to display all the players in the current room
        [SerializeField]
        private GameObject playerListingPrefab; //Instantiate to display each player in the room
        [SerializeField]
        private Text roomNameDisplay; //display for the name of the room

        PhotonView PV;

        bool room;

        private void Start()
        {

            ClearPlayerListings();
            ListPlayers();
        }


        void ClearPlayerListings()
        {
            for (int i = playersContainer.childCount - 1; i >= 0; i--) //loop through all child object of the playersContainer, removing each child
            {
                Destroy(playersContainer.GetChild(i).gameObject);
            }
        }

        void ListPlayers()
        {

            foreach (Player player in PhotonNetwork.PlayerList) //loop through each player and create a player listing
            {

                GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
                Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
                tempText.text = player.NickName;

            }

    }




    }
}
