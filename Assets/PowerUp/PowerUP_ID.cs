using Photon.Pun;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class PowerUP_ID : MonoBehaviour
    {
        public int ID;

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {

                if (other.GetComponent<PlayerPWUP>().slot1 == false || other.GetComponent<PlayerPWUP>().slot2 == false)
                {
                    if (other.GetComponent<PlayerPWUP>().slot2 && ID == other.GetComponent<PlayerPWUP>().ID_PWUP_slot2)
                    {
                        return;
                    }

                    if (other.GetComponent<PlayerPWUP>().slot1 && ID == other.GetComponent<PlayerPWUP>().ID_PWUP_slot1)
                    {
                        return;
                    }

                    gameObject.SetActive(false);
                    other.GetComponent<PlayerPWUP>().GetID(ID);
                    

                }
                
                
            }
        }

    }
}
