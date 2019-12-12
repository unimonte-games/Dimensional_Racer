using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomMatchmakingRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiPlayerSceneIndex; // Cena do Jogo

    [SerializeField]
    private GameObject lobbyPanel; //Exibir quando estiver no lobby
    [SerializeField]
    private GameObject roomPanel; //Exibir quando estiver no quarto

    [SerializeField]
    private GameObject startButton; //Somente para o cliente principal. usado para iniciar o jogo e carregar a cena.

    [SerializeField]
    private Transform playersContainer; //Exige os jogadores na sala atual
    [SerializeField]
    private GameObject playerListingPrefab; //Instancia cada jogador na sala

    [SerializeField]
    private Text roomNameDisplay; //Nome da Sala



    void ClearPlayerListings()
    {
        for (int i = playersContainer.childCount - 1; i >= 0; i--) //verifica todo o objeto filho do playersContainer, removendo cada filho
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    void ListPlayers() 
    {

        foreach (Player player in PhotonNetwork.PlayerList) //Cria a lita de jogadores
        {
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();

            tempText.text = player.NickName;
        }
        
    }


    public override void OnJoinedRoom() //chamado quando o jogador local entra na sala
    {
        roomPanel.SetActive(true); 
        lobbyPanel.SetActive(false); 
        roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name; //Nome da sala

        if (PhotonNetwork.IsMasterClient) //Somente o Dono da sala possui o botao de começar
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }

        
        ClearPlayerListings(); //Apaga todos os jogadores
        ListPlayers(); //Atualiza os jogadores
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) // toda vez que um jogador entra na sala ele lista tudo novamente
    {
        ClearPlayerListings(); //Apaga todos os jogadores
        ListPlayers(); //atualiza os jogadores
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)// toda vez que um jogador sai da sala, ele atualiza
    {
        ClearPlayerListings();//Apaga todos os jogadores
        ListPlayers();//atualiza os jogadores
        if (PhotonNetwork.IsMasterClient) //Se o jogador atual é o dono da sala, ele irá ver o botao de começar
        {
            startButton.SetActive(true);
        }
    }

    public void StartGame() //Ira carregar o jogo para todos os jogadores após clicar
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false; //Verifica se o jogador dono irá participar
            PhotonNetwork.LoadLevel(multiPlayerSceneIndex);   //carrega a cena
        }
    }

    IEnumerator rejoinLobby()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.JoinLobby();
    }

    public void BackOnClick() //Cancelar
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        StartCoroutine(rejoinLobby());
    }

    
}
