using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class GameModeSystem : MonoBehaviour
    {

        public Transform Player;

        public int ModeRace;
        public int Nos;
        public int Nos_count;

        public int[] ListSprint;
       
        public int AtualCheck;
        public int AtualDestiny;
      
        public ListSprint LS;

        public Text NostTxt;
        public Text NosAtual;

        public GameObject NextKnot;
        public GameObject LastKnot;

        public Transform LastCheck;

        public GameObject Victory_Obj;
        public GameObject Defeat_Obj;
     
        public GameObject Winner_Cube;
        
        PhotonView PV;

        bool isPronto;
        public bool Win;
        public PlayerPWUP pwup;
      

        private void Start()
        {
            LS = FindObjectOfType<ListSprint>();
            PV = GetComponent<PhotonView>();

            if (PV.IsMine)
            {
                Nos = 7;

                ListSprint[0] = 11;
                ListSprint[1] = 5;
                ListSprint[2] = 12;
                ListSprint[3] = 0;
                ListSprint[4] = 2;
                ListSprint[5] = 6;
                ListSprint[6] = 4;

                PV.RPC("UpdateInterface", RpcTarget.All);
                
            }

            Invoke("NewDestiny", 25);
            Debug.Log("Iniciando Percurso!");

        }

        public void CallBackTODestiny()
        {
            Player.position = LastCheck.position;
        }

        public void NewDestiny()
        {
            UpdateInterface();

            AtualDestiny = ListSprint[Nos_count];
            LS.CheckList[AtualDestiny].SetActive(true);
            Player.position = LS.Destiny[AtualDestiny].position;
            LastCheck = LS.Destiny[AtualDestiny];
        }

        IEnumerator NextKnotCancel(int value)
        {
            if(value == 1)
            {
                yield return new WaitForSeconds(2);
                NextKnot.SetActive(false);
            }

            if (value == 2)
            {

                yield return new WaitForSeconds(2);
                LastKnot.SetActive(false);

            }

        }

        public void GetCheck(int ValueCheck, Transform refference)
        {

            AtualCheck = ValueCheck;
            if (AtualCheck == LS.ValueToCheck[ListSprint[Nos_count]])
            {
                Debug.Log("Encerrou o Percurso do nó: " + Nos_count);
                AtualCheck = 0;
            }

            LastCheck = refference;
        }

        public void Teleport()
        {

            Debug.Log("Indo pro proximo nó");
            LS.CheckList[AtualDestiny].SetActive(false);
            
            Nos_count++;

            if (PV.IsMine)
            {
                PV.RPC("UpdateInterface", RpcTarget.All);
            }

            if (Nos_count == Nos)
            {
                if (Win == false)
                {
                    Win = true;

                    PV.RPC("SetWinner", RpcTarget.All);
                    Debug.Log("Voce venceu!");
                }
                return;
            }

            if (Nos_count == Nos - 1)
            {
                Debug.Log("Esse é teu penultimo nó");

                LastKnot.SetActive(true);
                StartCoroutine("NextKnotCancel", 2);


            }
            else
            {
                NextKnot.SetActive(true);
                StartCoroutine("NextKnotCancel", 1);
            }

            NewDestiny();

        }

        [PunRPC]
        public void SetWinner()
        {

            Winner_Cube.SetActive(true);
            Victory_Obj.SetActive(true);

            GetComponentInChildren<Victory>().SetWinner = true;
            GetComponentInChildren<Victory>().ID = pwup.PhotonID_User;
 
        }


        [PunRPC] 
        public void SetDefeat()
        {
            Defeat_Obj.SetActive(true);
            
        }

        [PunRPC]
        public void UpdateInterface()
        {
            NostTxt.text = "" + Nos;
            NosAtual.text = "" + Nos_count;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Victory" && PV.IsMine && Win == false)
            {
                if (other.gameObject.GetComponent<Victory>().ID == pwup.PhotonID_User)
                {
                    Debug.Log("Voce Venceu!!!");
                    return;
                }
                else if (other.gameObject.GetComponent<Victory>().SetWinner == true)
                {
                    PV.RPC("SetDefeat", RpcTarget.All);
                    Debug.Log("Voce perdeu!");

                    Win = true;
                }

            }
     
        }

    }
}

    

