using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class GetIDView : MonoBehaviour
    {
        public int ID_View;
        public int TypeToHit;
        public int TimeToDestroy;
        public string NameToSetThis;


        private void Start()
        {
            Invoke("destroyThis", TimeToDestroy);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {


                if (other.GetComponent<PlayerPWUP>().Shield)
                {
                    Debug.Log("Voce esta protegido!");
                    return;
                }

                if (TypeToHit == 1) //ICE
                {
                    other.GetComponent<PlayerPWUP>().Ice_Hit(ID_View, TypeToHit);
                    other.GetComponent<PlayerPWUP>().danger_SetName = NameToSetThis;
                }


                if (TypeToHit == 3) //ESFERA
                {
                    other.GetComponent<PlayerPWUP>().Esfera_Hit(ID_View, TypeToHit);
                    other.GetComponent<PlayerPWUP>().danger_SetName = NameToSetThis;

                }


                if (TypeToHit == 4) //VENENO
                {
                    other.GetComponent<PlayerPWUP>().Veneno_Hit(ID_View, TypeToHit);
                    other.GetComponent<PlayerPWUP>().danger_SetName = NameToSetThis;

                }

                if (TypeToHit == 7) //CHOQUE
                {
                    other.GetComponent<PlayerPWUP>().Choque_Hit(ID_View, TypeToHit);
                    other.GetComponent<PlayerPWUP>().danger_SetName = NameToSetThis;

                }


                if (TypeToHit == 8) //CHAMAS
                {
                    other.GetComponent<PlayerPWUP>().Chamas_Hit(ID_View, TypeToHit);
                    other.GetComponent<PlayerPWUP>().danger_SetName = NameToSetThis;

                }
            }
        }

        void destroyThis()
        {
            //gameObject.SetActive(false);
            PhotonNetwork.Destroy(gameObject);
        }

    }
}
