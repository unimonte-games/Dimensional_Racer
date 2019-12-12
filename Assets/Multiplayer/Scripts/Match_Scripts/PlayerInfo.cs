using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;
    public string mySelectedCharacter_Name;
    public int mySelectedCharacter_ID = 0;
    public string[] allCharacter;

    private void OnEnable()
    {
        if(PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if (PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
                PlayerInfo.PI = this;
            }

        }
    }


    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter_List"))
        {
            mySelectedCharacter_Name = PlayerPrefs.GetString("MyCharacter_List");
        }
        else
        {
            mySelectedCharacter_Name = allCharacter[mySelectedCharacter_ID];
            PlayerPrefs.SetString("MyCharacter_List", mySelectedCharacter_Name);
        }
    }
}
