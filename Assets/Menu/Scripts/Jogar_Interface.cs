using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogar_Interface : MonoBehaviour
{

    public Animation Canvas_Animation;
    public GameObject[] Characters;



    public void SelectCharacter()
    {
        Canvas_Animation.Play("Interface_IrParaCharacter");
    }

    public void CharacterSelection(int Char) //Carregar o atual click e desativa todas as anteriores
    {

        for (int i = 0; i <= 3; i++)
        {
            
            Characters[i].SetActive(false);
            

        }

        Characters[Char].SetActive(true);
     
    }

    public void IrParaLobby()
    {
        Canvas_Animation.Play("Interface_IrParaLobby");
    }

   
    public void IrParaRoom()
    {
        Canvas_Animation.Play("Interface_IrParaRoom");
    }

    public void VoltarParaLobby()
    {
        Canvas_Animation.Play("Interface_VoltarParaLobby");
    }

    public void VoltarParaCharac()
    {
        Canvas_Animation.Play("Interface_VoltarParaCharacter");
    }

    public void VoltarParaMenu()
    {
        Canvas_Animation.Play("Interface_VoltarParaMenu");
    }


}
