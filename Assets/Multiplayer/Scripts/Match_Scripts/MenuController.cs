using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public static MenuController MC;

    public GameObject CharactersLobby;
    public GameObject BTT;
    public string AtualCharacter;
    public Text NameCharacter;
    public Text AtualNameInLobby;

    private void Start()
    {
        InvokeRepeating("SetName", 0, 120);
    }

    void SetName()
    {
        NameCharacter.text = "" + PlayerPrefs.GetString("NickName");
    }

    public void OnClickCharacterPick (int whiteCharacter)
    {
        if(PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter_ID = whiteCharacter;
            PlayerInfo.PI.mySelectedCharacter_Name = PlayerInfo.PI.allCharacter[PlayerInfo.PI.mySelectedCharacter_ID];
            PlayerPrefs.SetString("MyCharacter_List", PlayerInfo.PI.mySelectedCharacter_Name);

            //AtualCharacter = PlayerInfo.PI.mySelectedCharacter_Name;
            //NameCharacter.text = "" + AtualCharacter;
            //AtualNameInLobby.text = "" + AtualCharacter;
           
        }
    }

    public void OnClickToLobby()
    {
        CharactersLobby.SetActive(false);
        BTT.SetActive(true);
    }

    public void OnClickViewToCharacters()
    {
        CharactersLobby.SetActive(true);
        BTT.SetActive(false);
    }
}
