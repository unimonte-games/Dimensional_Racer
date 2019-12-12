using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class TeleportDestiny : MonoBehaviour
    {
        public int ID_ToCheck; //Verifica em qual dos checkpoints estamos
        public GameObject NextCheck; //Objeto que indica o proximo check
        public Transform reff; //Referencia para usarmos o teleporte de ajuda
        

        public bool isTeleport; //Se esse objeto é um teleport


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player") //colisao com player
            {
                GameModeSystem tempGMS = other.GetComponentInChildren<GameModeSystem>();

                if (tempGMS.AtualCheck == ID_ToCheck && isTeleport == false) 
                {//Verifica se já completamos a lista de check e se somos um teleport
                    return;
                }

                if (isTeleport) // se for um teleport, iremos pro proximo
                {
                    tempGMS.Teleport(); //Vamos para o proximo nó
                    NextCheck.SetActive(true); //iremos reativar o check1, para caso repetirmos esse nó
                    this.gameObject.SetActive(false); //após colidir, vai ficar desativado
                    return;
                }


                tempGMS.GetCheck(ID_ToCheck, reff); //iremos pro proximo check desse nó
                NextCheck.SetActive(true);

                this.gameObject.SetActive(false); //Esse check é desativado

            }
        }
    }
}
