using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CustomMatchmakingLobbyController : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private GameObject lobbyConnectButton; 
        [SerializeField]
        private GameObject lobbyCancel;
        [SerializeField]
        private GameObject MainMenu;

        public GameObject Loading;

        public InputField playerNameInput;

        private string roomName; 
        private int roomSize; 

        private List<RoomInfo> roomListings; 
        [SerializeField]
        private Transform roomsContainer; 
        [SerializeField]
        private GameObject roomListingPrefab; 


        public override void OnConnectedToMaster() 
        {
            //Faz com que qualquer cena que o cliente principal carregou seja a cena que todos os outros clientes carregarão
            PhotonNetwork.AutomaticallySyncScene = true;

            lobbyConnectButton.SetActive(true);  // botão de ativação para conectar ao lobby
            Loading.SetActive(false);   
            roomListings = new List<RoomInfo>();  //inicializando roomListing


            // verifica o nome do jogador salvo nos PlayerPrefs
            if (PlayerPrefs.HasKey("NickName"))
            {
                if (PlayerPrefs.GetString("NickName") == "")
                {
                    PhotonNetwork.NickName = "Player " + Random.Range(0, 1000); // nome aleatório do jogador se nao colocar nada
                }
                else
                {
                    PhotonNetwork.NickName = PlayerPrefs.GetString("NickName"); // é salvo o nome do jogador
                }
            }
            else
            {
                PhotonNetwork.NickName = "Player " + Random.Range(0, 1000); //nome aleatório do jogador quando não está definido
            }
            playerNameInput.text = PhotonNetwork.NickName; //Atualiza o nome do jogador após ele escrever
        }

        public void PlayerNameUpdate(string nameInput) //função de entrada para o nome do jogador. Fica na escrita do player
        {
            PhotonNetwork.NickName = nameInput;
            PlayerPrefs.SetString("NickName", nameInput);
            playerNameInput.text = nameInput;
        }

        public void JoinLobbyOnClick() //Ao clicar em "entrar"
        {
            PhotonNetwork.JoinLobby(); 
            MainMenu.SetActive(true);
        }


        public override void OnRoomListUpdate(List<RoomInfo> roomList) //Atualizar salas
        {
            int tempIndex;
            foreach (RoomInfo room in roomList) // percorre cada sala na lista de salas
            {
                if (roomListings != null) // Tenta encontrar alguma lista de quartos existente
                {
                    tempIndex = roomListings.FindIndex(ByName(room.Name));
                }
                else
                {
                    tempIndex = -1;
                }
                if (tempIndex != -1) // remover listagem depois que foi fechada
                {
                    roomListings.RemoveAt(tempIndex);
                    Destroy(roomsContainer.GetChild(tempIndex).gameObject);
                }
                if (room.PlayerCount > 0) //Adiciona lista quando for nova
                {
                    roomListings.Add(room);
                    ListRoom(room);
                }
            }
        }



        static System.Predicate<RoomInfo> ByName(string name)// Pesquisar na lista de salas
        {
            return delegate (RoomInfo room)
            {
                return room.Name == name;
            };
        }

        void ListRoom(RoomInfo room) // exibe uma nova listagem de salas para a sala atual
        {
            if (room.IsOpen && room.IsVisible)
            {
                GameObject tempListing = Instantiate(roomListingPrefab, roomsContainer);
                RoomButton tempButton = tempListing.GetComponent<RoomButton>();
                tempButton.SetRoom(room.Name, room.MaxPlayers, room.PlayerCount);
            }
        }

        public void OnRoomNameChanged(string nameIn) //Funcao para mudar o nome da sala
        {
            roomName = nameIn;
        }
        public void OnRoomSizeChanged(string sizeIn) //Funcao para trcar o tamanho da sala
        {

            bool Result;
            int number;

            Result = int.TryParse(sizeIn, out number);
            if (Result)
            {
                if (number >= 15)
                {
                    number = 15;
                }

                roomSize = number;

            }

        }

        public void CreateRoomOnClick() //Criaçao de Sala
        {

            Debug.Log("Criando Sala");
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
            PhotonNetwork.CreateRoom(roomName, roomOps); 

            lobbyCancel.SetActive(false);
        }

        public override void OnCreateRoomFailed(short returnCode, string message) //Verifica se a sala já existe
        {
            Debug.Log("Tem uma sala com o mesmo nome");
        }



        public void MatchmakingCancelOnClick() //Voltar ao menu
        {

            PhotonNetwork.LeaveLobby();
            VoltarSelect();
        }

        void VoltarSelect()
        {
            lobbyCancel.SetActive(true);
        }
    }

}
