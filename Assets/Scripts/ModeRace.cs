using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class ModeRace : MonoBehaviour
    {
        public int[] tempListSprint;
        public string[] SetPlayPrefs;

        private void Start() //Zera os valores atuais
        {
            PlayerPrefs.SetInt("ModeRace", 0);
            PlayerPrefs.SetInt("ModeNos", 0);
        }
        public void SetTest_Corrida (int value) //Botao que irá atualizar o modo de jogo
        {
            PlayerPrefs.SetInt("ModeRace", value);

        }

        public void SetTest_Nos(int value) //botao que irá atualizar as corridas
        {
            if(value == 1) //Curta 1-3
            {
                int Nos = Random.Range(1, 3);
                PlayerPrefs.SetInt("ModeNos", Nos);
                SetListRoom(Nos);
                return;
            }

            if (value == 2) //Media 4-6
            {
                int Nos = Random.Range(4, 6);
                PlayerPrefs.SetInt("ModeNos", Nos);
                SetListRoom(Nos);
                return;
            }

            if (value == 3) //Grande 10-15
            {
                int Nos = Random.Range(7, 9);
                PlayerPrefs.SetInt("ModeNos", Nos);
                SetListRoom(Nos);
                return;
            }

            if (value == 4) //Gigante 16-20
            {
                int Nos = Random.Range(10, 12);
                PlayerPrefs.SetInt("ModeNos", Nos);
                SetListRoom(Nos);
                return;
            }

            if (value == 5) //Maratona 21-25
            {
                int Nos = Random.Range(13, 15);
                PlayerPrefs.SetInt("ModeNos", Nos);
                SetListRoom(Nos);
                return;
            }
        }

        void SetListRoom(int value)
        {

            for (int i = 0; i <= value; i++) //Nó
            {
                int RandomLocation;
                RandomLocation = Random.Range(0, 10);

                for (int j = 0; j <= value; j++) //Verifica se tem algum outro nó igual a ele
                {

                    if (RandomLocation == tempListSprint[j]) //Um a um ele irá checar
                    {
                        RandomLocation = Random.Range(0, 10); //novo numero
                    }

                }


                tempListSprint[i] = RandomLocation;
                
            }

            SetPlayerPrefs();


        }

        public void SetPlayerPrefs()
        {
            for (int i = 0; i <= 15; i++)
            {
                PlayerPrefs.SetInt(SetPlayPrefs[i], tempListSprint[i]); 
            }

            Debug.Log("Set Player Prefs");
        }

    }
}
