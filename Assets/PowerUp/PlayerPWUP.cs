using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class PlayerPWUP : MonoBehaviour
    {

        private PhotonView PV;
        private ThirdPersonCharacter m_character;
        private ThirdPersonUserControl m_control;
        private GameModeSystem GMS;
        public GameObject m_Player;
        public string[] SetPlayPrefs;

        public GameObject GetSlot1;
        public GameObject GetSlot2;

        public GameObject[] getSlot1;
        public GameObject[] getSlot2;

        public GameObject[] slotUsing1;
        public GameObject[] slotUsing2;

        public GameObject dangerObj;
        public GameObject[] danger;
        public Text[] danger_Name;
        public string danger_SetName;


        public GameObject Interface_UI_1;
        public GameObject Interface_UI_2;
        public GameObject Interface_UI_3;

        public bool Interface;
        public string Name;
        public Text Name_UI;
        

        public Transform spawn;
        public Transform spawn_atras;
        public Transform spawn_center;

        public Transform spawn_1;
        public Transform spawn_2;


        public GameObject[] PWUP_List; //Efeitos no Player
        public GameObject[] Conseguence_List; //Efeitos ao tomar hit
        public string[] AreaEffect;

        public string[] GetPW; //Nome Para RPC

        public int ID_PWUP_slot1;
        public int ID_PWUP_slot2;

        public int ID_Conseguence;
        public bool Hit_Atived;

        public bool slot1;
        public bool slot2;

        public bool Slot1_Using;
        public bool Slot2_Using;

        public int PhotonID_User;

        int Ice_Count;
        int Teleporter_Count;
        public Transform Teleporter_Spawn;
        public bool Shield;
        bool isReady;

        bool Click_1;
        bool Click_2;

        private void Start()
        {
            
            PV = GetComponent<PhotonView>();
            m_character = GetComponent<ThirdPersonCharacter>();
            m_control = GetComponent<ThirdPersonUserControl>();
            GMS = GetComponentInChildren<GameModeSystem>();
            

            if (PV.IsMine)
            {
                Interface_UI_3.SetActive(true);
                PhotonID_User = PV.ViewID;
                PV.RPC("SetName", RpcTarget.All);

            }
            else
            {
                GMS.enabled = false;
            }
            
        }

        [PunRPC]
        public void SetName()
        {
            Name = PhotonNetwork.NickName;
            Name_UI.text = Name;
        }

        public void GetID(int ID)
        {

            if (slot1 == false)
            {

                ID_PWUP_slot1 = ID;
                slot1 = true;

                GetSlot1.SetActive(true);
                getSlot1[ID_PWUP_slot1].SetActive(true);


                Debug.Log("Salvo no Slot 1");
                return;

            }

            if (slot2 == false)
            {


                ID_PWUP_slot2 = ID;
                slot2 = true;
                GetSlot2.SetActive(true);
                getSlot2[ID_PWUP_slot2].SetActive(true);


                Debug.Log("Salvo no Slot 2");
                return;
            }
            

        }

        void FixedUpdate()
        {
            if (PV.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.Q) && Click_1 == false)
                {
                    if (slot1)
                    {
                        PV.RPC(GetPW[ID_PWUP_slot1], RpcTarget.All, 1);
                        PV.RPC("SetName", RpcTarget.All);
                    }
                }

                if (Input.GetKeyDown(KeyCode.E) && Click_2 == false)
                {
                    if (slot2)
                    {
                        PV.RPC(GetPW[ID_PWUP_slot2], RpcTarget.All, 2);
                        PV.RPC("SetName", RpcTarget.All);
                    }
                }

                if (Input.GetKeyDown(KeyCode.T))
                {
                    GMS.CallBackTODestiny();
                }

                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    GMS.Nos = 5;

                    GMS.ListSprint[0] = 11;
                    GMS.ListSprint[1] = 5;
                    GMS.ListSprint[2] = 12;
                    GMS.ListSprint[3] = 0;
                    GMS.ListSprint[4] = 2;
                    
                   
             
                }

                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    GMS.Nos = 5;

                    GMS.ListSprint[0] = 2;
                    GMS.ListSprint[1] = 11;
                    GMS.ListSprint[2] = 4;
                    GMS.ListSprint[3] = 1;
                    GMS.ListSprint[4] = 12;
                  
                   

                }

                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    GMS.Nos = 7;

                    GMS.ListSprint[0] = 0;
                    GMS.ListSprint[1] = 3;
                    GMS.ListSprint[2] = 10;
                    GMS.ListSprint[3] = 1;
                    GMS.ListSprint[4] = 11;
                    GMS.ListSprint[5] = 5;
                    GMS.ListSprint[6] = 6;
                 

                  

                }

                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    GMS.Nos = 7;

                    GMS.ListSprint[0] = 1;
                    GMS.ListSprint[1] = 5;
                    GMS.ListSprint[2] = 10;
                    GMS.ListSprint[3] = 3;
                    GMS.ListSprint[4] = 11;
                    GMS.ListSprint[5] = 6;
                    GMS.ListSprint[6] = 4;
                    GMS.ListSprint[7] = 6;
                    
              
                }

                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    GMS.Nos = 10;

                    GMS.ListSprint[0] = 0;
                    GMS.ListSprint[1] = 1;
                    GMS.ListSprint[2] = 2;
                    GMS.ListSprint[3] = 3;
                    GMS.ListSprint[4] = 4;
                    GMS.ListSprint[5] = 5;
                    GMS.ListSprint[6] = 6;
                    GMS.ListSprint[7] = 10;
                    GMS.ListSprint[8] = 11;
                    GMS.ListSprint[9] = 12;
                    GMS.ListSprint[10] = 5;


                }

               
            
                if (Input.GetKeyDown(KeyCode.Alpha0) && isReady)
                {
                    GMS.Nos = 3;

                }


            }
        }

        void Delay1()
        {
            Click_1 = false;
            
            CancelInvoke("Delay1");
        }
        void Delay2()
        {
            Click_2 = false;
            
            CancelInvoke("Delay2");
        }

        //______Gatilhos de PowerUp_______________________

        [PunRPC]
        void PowerUP3_Velocidade(int slot)
        {
           
            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                
                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);


                slotUsing1[ID_PWUP_slot1].SetActive(true);

                m_character.m_MoveSpeedMultiplier = 25f;
                m_character.m_AnimSpeedMultiplier = 3f;
                Debug.Log("Power UP (Velocidade)- Iniciado");

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect
               


                StartCoroutine("Cancel_Speed", 1);


                return;

            }
            else
            {
                Debug.Log("Esse Power UP Já está sendo usado!");
            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                
                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);


                slotUsing2[ID_PWUP_slot2].SetActive(true);

                m_character.m_MoveSpeedMultiplier = 25f;
                m_character.m_AnimSpeedMultiplier = 3f;
                Debug.Log("Power UP (Velocidade)- Iniciado");

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect


                StartCoroutine("Cancel_Speed", 2);


                return;
            }
            else
            {
                Debug.Log("Esse Power UP Já está sendo usado!");
            }

        }
        IEnumerator Cancel_Speed(int slot)
        {

            yield return new WaitForSeconds(10);

            m_character.m_MoveSpeedMultiplier = 20f;
            m_character.m_AnimSpeedMultiplier = 1f;

            if (slot == 1)
            {
                slot1 = false;
                Slot1_Using = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect
                Debug.Log("Slot 1 (Vazio)");

                
                slotUsing1[ID_PWUP_slot1].SetActive(false);


                Invoke("Delay1",1f);
                yield break;


            }

            if (slot == 2)
            {
                slot2 = false;
                Slot2_Using = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect
                Debug.Log("Slot 2 (Vazio)");


                slotUsing2[ID_PWUP_slot2].SetActive(false);


                Invoke("Delay2", 1);
                yield break;


            }

        }

        [PunRPC]
        void PowerUP5_Ice(int slot)
        {

            if (slot == 1)
            {
                Click_1 = true;


                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);


                slotUsing1[ID_PWUP_slot1].SetActive(true);

                if (Slot1_Using == false)
                {
                    Slot1_Using = true;
                    PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect
                    Ice_Count = 0;
                }
                else
                {
                    Ice_Count += 1;

                    GameObject ice = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn.transform.position, spawn.transform.rotation, 0);
                    ice.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    ice.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                    ice.GetComponent<GetIDView>().NameToSetThis = Name;

                    if (Ice_Count >= 3)
                    {
                        Slot1_Using = false;
                        slot1 = false;
                        PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect


                        slotUsing1[ID_PWUP_slot1].SetActive(false);
                        
                        Debug.Log("Power UP - Ice, acabou.");
                    }
                }

                Invoke("Delay1", 1);
                return;

            }
            if (slot == 2)
            {
                Click_2 = true;


                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);


                slotUsing2[ID_PWUP_slot2].SetActive(true);


                if (Slot2_Using == false)
                {
                    Slot2_Using = true;
                    Ice_Count = 0;
                    PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect


                }
                else
                {
                    Ice_Count += 1;

                    GameObject ice = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn.transform.position, spawn.transform.rotation, 0);
                    ice.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    ice.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                    ice.GetComponent<GetIDView>().NameToSetThis = Name;

                    if (Ice_Count >= 3)
                    {
                        Slot2_Using = false;
                        slot2 = false;
                        PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                        slotUsing2[ID_PWUP_slot2].SetActive(false);
                        
                        Debug.Log("Power UP - Ice, acabou.");
                    }
                }

                Invoke("Delay2", 1);
                return;

            }


        }

        [PunRPC]
        void PowerUP7_Neblina(int slot)
        {

            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect


                GameObject neblina = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn_atras.transform.position, spawn_atras.transform.rotation, 0);

                
                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);


                slotUsing1[ID_PWUP_slot1].SetActive(true);

                

                StartCoroutine("Neblina_cancel", 1);
                return;

            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect


                GameObject neblina = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn_atras.transform.position, spawn_atras.transform.rotation, 0);

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                StartCoroutine("Neblina_cancel", 2);
                return;

            }


        }
        IEnumerator Neblina_cancel(int slot)
        {
            yield return new WaitForSeconds(3);

            if (slot == 1)
            {
                
                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect
                
                slotUsing1[ID_PWUP_slot1].SetActive(false);

                Invoke("Delay1", 1);       
                Debug.Log("Power UP - Neblina, acabou.");
                yield break;
            }

            if (slot == 2)
            {

                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                
                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Invoke("Delay2", 1); 
                Debug.Log("Power UP - Neblina, acabou.");
                yield break;
            }
        }

        [PunRPC]
        void PowerUP8_Esfera (int slot)
        {
            if(slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

                StartCoroutine("Cancel_Esferas", 1);
                return;
            }

            if(slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                StartCoroutine("Cancel_Esferas", 2);
                return;
            }
        }
        IEnumerator Cancel_Esferas(int slot)
        {
            yield return new WaitForSeconds(1);

            if(slot == 1)
            {
                
                for (int i = 1; i <= 3; i++)
                {
                    yield return new WaitForSeconds(2);
                    GameObject Esferas1 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn.transform.position, spawn.transform.rotation, 0);
                    Esferas1.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Esferas1.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                    Esferas1.GetComponent<GetIDView>().NameToSetThis = Name;
                }

                Slot1_Using = false;
                slot1 = false;
         

                slotUsing1[ID_PWUP_slot1].SetActive(false);


                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect
                Invoke("Delay1", 1);
                yield break;

            }

            if (slot == 2)
            { 

                for (int i = 1; i <= 3; i++)
                {
                    yield return new WaitForSeconds(2);
                    GameObject Esferas2 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn.transform.position, spawn.transform.rotation, 0);
                    Esferas2.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Esferas2.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                    Esferas2.GetComponent<GetIDView>().NameToSetThis = Name;
                }

                Slot2_Using = false;
                slot2 = false;     

                slotUsing2[ID_PWUP_slot2].SetActive(false);

                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect
                Invoke("Delay2", 1);
                yield break;

            }
        }

        [PunRPC]
        void PowerUP6_Veneno (int slot)
        {
            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                getSlot1[ID_PWUP_slot1].SetActive(false);
                GetSlot1.SetActive(false);


                slotUsing1[ID_PWUP_slot1].SetActive(true);

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

                StartCoroutine("Cancel_Veneno", 1);
                return;
            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                StartCoroutine("Cancel_Veneno", 2);
                return;
            }
        }
        IEnumerator Cancel_Veneno(int slot)
        {

            if (slot == 1)
            {

                for (int i = 1; i <= 3; i++)
                {
                    yield return new WaitForSeconds(3);
                    GameObject Veneno1 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn.transform.position, spawn.transform.rotation, 0);
                    Veneno1.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Veneno1.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                    Veneno1.GetComponent<GetIDView>().NameToSetThis = Name;
                }
 
                slotUsing1[ID_PWUP_slot1].SetActive(false);

                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect
                Invoke("Delay1", 2);

                yield break;

            }


            if (slot == 2)
            {

                for (int i = 1; i <= 3; i++)
                {
                    yield return new WaitForSeconds(3);
                    GameObject Veneno2 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn.transform.position, spawn.transform.rotation, 0);
                    Veneno2.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Veneno2.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                    Veneno2.GetComponent<GetIDView>().NameToSetThis = Name;
                }
               
                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect
                Invoke("Delay2", 2);

                yield break;

            }
        }

        [PunRPC]
        void PowerUP2_Escudo (int slot)
        {

            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                Shield = true;
                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

               
                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);

                

                StartCoroutine("Escudo_cancel", 1);
                return;

            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                
                
                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                Shield = true;
                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                StartCoroutine("Escudo_cancel", 2);
                return;

            }
        }
        IEnumerator Escudo_cancel(int slot)
        {
            yield return new WaitForSeconds(30);

            if (slot == 1)
            {
                Shield = false;
                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect

                
                slotUsing1[ID_PWUP_slot1].SetActive(false);

               

                Invoke("Delay1", 1);
                
                Debug.Log("Power UP - Escudo, acabou.");

                yield break;
            }

            if (slot == 2)
            {
                Shield = false;
                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Invoke("Delay2", 1);
                
                Debug.Log("Power UP - Escudo, acabou.");

                yield break;
            }
        }

        [PunRPC]
        void PowerUP1_Desarme (int slot)
        {
            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

                
                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);

               
                if (Hit_Atived)
                {
                    dangerObj.SetActive(false);
                    danger[ID_Conseguence].SetActive(false);

                    if (ID_Conseguence == 1)
                    {
                        StopCoroutine("Ice_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;

                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                    if (ID_Conseguence == 3)
                    {
                        StopCoroutine("Esfera_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;


                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                    if (ID_Conseguence == 4)
                    {
                        StopCoroutine("Veneno_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_control.ConfusedMove = false;
                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;

                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                    if (ID_Conseguence == 7)
                    {
                        StopCoroutine("Choque_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;


                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                    if (ID_Conseguence == 8)
                    {
                        StopCoroutine("Chamas_TimeToHit");

                        m_control.ConfusedMove = false;
                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect
                        
                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;


                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                }

                StartCoroutine("Desarme_cancel", 1);
                return;

            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                if (Hit_Atived)
                {
                    if (ID_Conseguence == 1)
                    {
                        StopCoroutine("Ice_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;

                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 2);
                        return;

                    }

                    if (ID_Conseguence == 3)
                    {
                        StopCoroutine("Esfera_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;


                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 2);
                        return;

                    }

                    if (ID_Conseguence == 4)
                    {
                        StopCoroutine("Veneno_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_control.ConfusedMove = false;
                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;

                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 2);
                        return;

                    }

                    if (ID_Conseguence == 7)
                    {
                        StopCoroutine("Choque_TimeToHit");

                        Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

                        m_character.m_MoveSpeedMultiplier = 22f;
                        m_character.m_AnimSpeedMultiplier = 1f;


                        Hit_Atived = false;
                        StartCoroutine("Desarme_cancel", 1);
                        return;

                    }

                }

                StartCoroutine("Desarme_cancel", 2);
                return;

            }
        }
        IEnumerator Desarme_cancel(int slot)
        {
            yield return new WaitForSeconds(3);

            if (slot == 1)
            {
                
                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect

                slotUsing1[ID_PWUP_slot1].SetActive(false);

                Invoke("Delay1", 1);
                
                Debug.Log("Power UP - Desarme, acabou.");

                yield break;
            }

            if (slot == 2)
            {
                
                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect
  
                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Invoke("Delay2", 1);
                
                Debug.Log("Power UP - Desarme, acabou.");

                yield break;
            }
        }

        [PunRPC]
        void PowerUP9_Choque(int slot)
        {

            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

                GameObject Choque1 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn_center.transform.position, spawn_center.transform.rotation, 0);
                Choque1.GetComponent<GetIDView>().ID_View = PhotonID_User;
                Choque1.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                Choque1.transform.parent = spawn_center.transform;
                Choque1.GetComponent<GetIDView>().NameToSetThis = Name;

                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);

                
                StartCoroutine("Choque_cancel", 1);
                return;

            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                GameObject Choque1 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn_center.transform.position, spawn_center.transform.rotation, 0);
                Choque1.GetComponent<GetIDView>().ID_View = PhotonID_User;
                Choque1.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                Choque1.transform.parent = spawn_center.transform;
                Choque1.GetComponent<GetIDView>().NameToSetThis = Name;
               
                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                StartCoroutine("Choque_cancel", 2);
                return;

            }


        }
        IEnumerator Choque_cancel(int slot)
        {
            yield return new WaitForSeconds(3);

            if (slot == 1)
            {

                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect

              
                slotUsing1[ID_PWUP_slot1].SetActive(false);


                Invoke("Delay1", 1);
                
                Debug.Log("Power UP - Choque, acabou.");

                yield break;

            }

            if (slot == 2)
            {

                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Invoke("Delay2", 1);
                
                Debug.Log("Power UP - Choque, acabou.");

                yield break;
            }
        }

        [PunRPC]
        void PowerUP10_Chamas(int slot)
        {
            if (slot == 1 && Slot1_Using == false)
            {
                Click_1 = true;

                Slot1_Using = true;
                PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect

                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);

                StartCoroutine("Chamas_cancel", 1);
                return;

            }

            if (slot == 2 && Slot2_Using == false)
            {
                Click_2 = true;

                Slot2_Using = true;
                PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                StartCoroutine("Chamas_cancel", 2);
                return;

            }

        }
        IEnumerator Chamas_cancel(int slot)
        {
         
            if (slot == 1)
            {
                for (int i = 1; i <= 5; i++)
                {
                    yield return new WaitForSeconds(2);

                    GameObject Chamas1 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn_1.transform.position, spawn_1.transform.rotation, 0);
                    Chamas1.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Chamas1.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                    Chamas1.GetComponent<GetIDView>().NameToSetThis = Name;

                    yield return new WaitForSeconds(2);

                    GameObject Chamas2 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot1]), spawn_2.transform.position, spawn_2.transform.rotation, 0);
                    Chamas2.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Chamas2.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot1;
                    Chamas2.GetComponent<GetIDView>().NameToSetThis = Name;

                }

                slotUsing1[ID_PWUP_slot1].SetActive(false);

                Slot1_Using = false;
                slot1 = false;
                PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect

                Invoke("Delay1", 3);
                
                Debug.Log("Power UP - Chamas, acabou.");
                yield break;
            }

            if (slot == 2)
            {
                for (int i = 1; i <= 5; i++)
                {
                    yield return new WaitForSeconds(2);

                    GameObject Chamas3 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn_1.transform.position, spawn_1.transform.rotation, 0);
                    Chamas3.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Chamas3.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                    Chamas3.GetComponent<GetIDView>().NameToSetThis = Name;

                    yield return new WaitForSeconds(2);

                    GameObject Chamas4 = PhotonNetwork.Instantiate(Path.Combine("Area Effect PowerUp", AreaEffect[ID_PWUP_slot2]), spawn_2.transform.position, spawn_2.transform.rotation, 0);
                    Chamas4.GetComponent<GetIDView>().ID_View = PhotonID_User;
                    Chamas4.GetComponent<GetIDView>().TypeToHit = ID_PWUP_slot2;
                    Chamas4.GetComponent<GetIDView>().NameToSetThis = Name;

                }

                
                slotUsing2[ID_PWUP_slot2].SetActive(false);

                Slot2_Using = false;
                slot2 = false;
                PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                Invoke("Delay2", 3);
                
                Debug.Log("Power UP - Chamas, acabou.");
                yield break;
            }
        }

        [PunRPC]
        void PowerUP4_Teleport(int slot)
        {
            if (slot == 1)
            {
                Click_1 = true;

                
                GetSlot1.SetActive(false);
                getSlot1[ID_PWUP_slot1].SetActive(false);

                slotUsing1[ID_PWUP_slot1].SetActive(true);
                
                if (Slot1_Using == false)
                {
                    Slot1_Using = true;
                    PWUP_List[ID_PWUP_slot1].SetActive(true); //User Effect
                    Teleporter_Count = 0;

                }
                else
                {
                    Teleporter_Count += 1;

                    gameObject.transform.position = Teleporter_Spawn.position;

                    if (Teleporter_Count >= 3)
                    {
                        Slot1_Using = false;
                        slot1 = false;
                        PWUP_List[ID_PWUP_slot1].SetActive(false); //User Effect

                        
                        slotUsing1[ID_PWUP_slot1].SetActive(false);
                        

                        Debug.Log("Power UP - Teleport, acabou.");
                    }
                }

                Invoke("Delay1", 1);
                return;

            }
            if (slot == 2)
            {
                Click_2 = true;

                GetSlot2.SetActive(false);
                getSlot2[ID_PWUP_slot2].SetActive(false);

                slotUsing2[ID_PWUP_slot2].SetActive(true);

                if (Slot2_Using == false)
                {
                    Slot2_Using = true;
                    Teleporter_Count = 0;
                    PWUP_List[ID_PWUP_slot2].SetActive(true); //User Effect

                }
                else
                {
                    Teleporter_Count += 1;

                    gameObject.transform.position = Teleporter_Spawn.position;

                    if (Teleporter_Count >= 3)
                    {
                        Slot2_Using = false;
                        slot2 = false;
                        PWUP_List[ID_PWUP_slot2].SetActive(false); //User Effect

                        
                        slotUsing2[ID_PWUP_slot2].SetActive(false);
                        
                        Debug.Log("Power UP - Teleport, acabou.");
                    }
                }

                Invoke("Delay2", 1);
                return;

            }


        }

        //_________Conseguencias______________________________

        public void Ice_Hit(int IDView, int ID_C)
        {
            if (PV.IsMine)
            {
                if (IDView == PhotonID_User)
                {
                    Debug.Log("Esse PowerUp foi instanciado por voce! (Sem dano)");
                    return;
                }

                ID_Conseguence = ID_C;
                PV.RPC("Start_IceHit", RpcTarget.All);
            }
            
        }
        [PunRPC]
        void Start_IceHit()
        {

            Hit_Atived = true;
            Conseguence_List[ID_Conseguence].SetActive(true); //Hit Effect

            dangerObj.SetActive(true);
            danger[ID_Conseguence].SetActive(true);
            danger_Name[ID_Conseguence].text = "" + danger_SetName;

            StartCoroutine("Ice_TimeToHit");

        }
        IEnumerator Ice_TimeToHit()
        {

            m_character.m_MoveSpeedMultiplier = 5f;
            m_character.m_AnimSpeedMultiplier = 0.5f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 3f;
            m_character.m_AnimSpeedMultiplier = 0.3f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 1f;
            m_character.m_AnimSpeedMultiplier = 0.1f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 0.0f;
            m_character.m_AnimSpeedMultiplier = 0.05f;

            yield return new WaitForSeconds(10); //Congelado

            m_character.m_MoveSpeedMultiplier = 3f;
            m_character.m_AnimSpeedMultiplier = 0.3f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 10f;
            m_character.m_AnimSpeedMultiplier = 0.5f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 18f;
            m_character.m_AnimSpeedMultiplier = 0.8f;

            yield return new WaitForSeconds(1);

            m_character.m_MoveSpeedMultiplier = 22f;
            m_character.m_AnimSpeedMultiplier = 1f;

            Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

            dangerObj.SetActive(false);
            danger[ID_Conseguence].SetActive(false);
            Debug.Log("Hit_Ice - Cancelado");
            Hit_Atived = false;

            yield break;

        }

        public void Esfera_Hit(int IDView, int ID_C)
        {
            if (PV.IsMine)
            {
                if (IDView == PhotonID_User)
                {
                    Debug.Log("Esse PowerUp foi instanciado por voce! (Sem dano)");
                    return;
                }

                ID_Conseguence = ID_C;
                PV.RPC("Start_EsferaHit", RpcTarget.All);
            }

        }
        [PunRPC]
        void Start_EsferaHit()
        {

            Hit_Atived = true;
            Conseguence_List[ID_Conseguence].SetActive(true); //Hit Effect

            dangerObj.SetActive(true);
            danger[ID_Conseguence].SetActive(true);
            danger_Name[ID_Conseguence].text = "" + danger_SetName;

            StartCoroutine("Esfera_TimeToHit");

        }
        IEnumerator Esfera_TimeToHit()
        {

            m_character.m_MoveSpeedMultiplier = 2f;
            m_character.m_AnimSpeedMultiplier = 0.3f;

            yield return new WaitForSeconds(5);

            m_character.m_MoveSpeedMultiplier = 22f;
            m_character.m_AnimSpeedMultiplier = 1f;

            Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

            dangerObj.SetActive(false);
            danger[ID_Conseguence].SetActive(false);
            GMS.CallBackTODestiny();

            Debug.Log("Esfera_Ice - Cancelado");
            Hit_Atived = false;

            yield break;

        }

        public void Veneno_Hit (int IDView, int ID_C)
        {
            if (PV.IsMine)
            {
                if (IDView == PhotonID_User)
                {
                    Debug.Log("Esse PowerUp foi instanciado por voce! (Sem dano)");
                    return;
                }

                ID_Conseguence = ID_C;
                PV.RPC("Start_VenenoHit", RpcTarget.All);
            }
        }
        [PunRPC]
        void Start_VenenoHit()
        {

            Hit_Atived = true;
            Conseguence_List[ID_Conseguence].SetActive(true); //Hit Effect

            dangerObj.SetActive(true);
            danger[ID_Conseguence].SetActive(true);
            danger_Name[ID_Conseguence].text = "" + danger_SetName;

            m_control.ConfusedMove = true;
            StartCoroutine("Veneno_TimeToHit");

        }
        IEnumerator Veneno_TimeToHit()
        {

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 5f;
            m_character.m_AnimSpeedMultiplier = 0.5f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 10f;
            m_character.m_AnimSpeedMultiplier = 5f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 1f;
            m_character.m_AnimSpeedMultiplier = 0.1f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);


            m_character.m_MoveSpeedMultiplier = 17f;
            m_character.m_AnimSpeedMultiplier = 3f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 5f;
            m_character.m_AnimSpeedMultiplier = 0.5f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 10f;
            m_character.m_AnimSpeedMultiplier = 5f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);

            m_character.m_MoveSpeedMultiplier = 1f;
            m_character.m_AnimSpeedMultiplier = 0.1f;

            yield return new WaitForSeconds(2);

            m_control.Confused_count = Random.Range(1, 4);


            m_character.m_MoveSpeedMultiplier = 17f;
            m_character.m_AnimSpeedMultiplier = 3f;

            yield return new WaitForSeconds(2);

            m_character.m_MoveSpeedMultiplier = 22f;
            m_character.m_AnimSpeedMultiplier = 1f;

            Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

            dangerObj.SetActive(false);
            danger[ID_Conseguence].SetActive(false);
           

            Debug.Log("Veneno - Cancelado");
            Hit_Atived = false;
            m_control.ConfusedMove = false;

            yield break;

        }

        public void Choque_Hit(int IDView, int ID_C)
        {
            if (PV.IsMine)
            {
                if (IDView == PhotonID_User)
                {
                    Debug.Log("Esse PowerUp foi instanciado por voce! (Sem dano)");
                    return;
                }

                ID_Conseguence = ID_C;
                PV.RPC("Start_ChoqueHit", RpcTarget.All);
            }

        }
        [PunRPC]
        void Start_ChoqueHit()
        {

            Hit_Atived = true;
            Conseguence_List[ID_Conseguence].SetActive(true); //Hit Effect

            dangerObj.SetActive(true);
            danger[ID_Conseguence].SetActive(true);
            danger_Name[ID_Conseguence].text = "" + danger_SetName;

            StartCoroutine("Choque_TimeToHit");

        }
        IEnumerator Choque_TimeToHit()
        {

            m_character.m_MoveSpeedMultiplier = 10f;
            m_character.m_AnimSpeedMultiplier = 0.5f;

            yield return new WaitForSeconds(7);

            m_character.m_MoveSpeedMultiplier = 22f;
            m_character.m_AnimSpeedMultiplier = 1f;

            Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

            dangerObj.SetActive(false);
            danger[ID_Conseguence].SetActive(false);
            

            Debug.Log("Choque - Cancelado");
            Hit_Atived = false;

            yield break;

        }

        public void Chamas_Hit(int IDView, int ID_C)
        {
            if (PV.IsMine)
            {
                if (IDView == PhotonID_User)
                {
                    Debug.Log("Esse PowerUp foi instanciado por voce! (Sem dano)");
                    return;
                }

                ID_Conseguence = ID_C;
                PV.RPC("Start_ChamasHit", RpcTarget.All);
            }

        }
        [PunRPC]
        void Start_ChamasHit()
        {

            Hit_Atived = true;
            Conseguence_List[ID_Conseguence].SetActive(true); //Hit Effect

            dangerObj.SetActive(true);
            danger[ID_Conseguence].SetActive(true);
            danger_Name[ID_Conseguence].text = "" + danger_SetName;

            StartCoroutine("Chamas_TimeToHit");

        }
        IEnumerator Chamas_TimeToHit()
        {

            m_control.ConfusedMove = true;

            yield return new WaitForSeconds(7);
            //Voltar ao Checkpoint

            m_control.ConfusedMove = false;
            Conseguence_List[ID_Conseguence].SetActive(false); //Hit Effect

            dangerObj.SetActive(false);
            danger[ID_Conseguence].SetActive(false);
            

            Debug.Log("Chamas - Cancelado");
            Hit_Atived = false;

            yield break;

        }




    }
}
        
