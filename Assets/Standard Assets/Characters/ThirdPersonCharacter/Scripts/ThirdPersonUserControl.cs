using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;
using System.Collections;
using UnityEngine.UI;
using System.IO;



namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {

        public static ThirdPersonUserControl U;

        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        public Camera Player_Cam;

        public GameObject CameraSet;
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private PhotonView PV;

        public bool ConfusedMove;
        public int Confused_count;


        float h;
        float v;
        bool crouch;

        public void Start()
        {
            PV = GetComponent<PhotonView>();

            if (!PV.IsMine)
            {

                Player_Cam.enabled = false;
                CameraSet.SetActive(false);


            }
            else
            {

                m_Cam = Player_Cam.transform;
                m_Character = GetComponent<ThirdPersonCharacter>();
                
                
               
               
            }
           
        }

        private void Update()
        {
            if (!m_Jump && PV.IsMine)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }



        }

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (PV.IsMine)
            {
                // read inputs
               
                if (ConfusedMove)
                {
                    if(Confused_count == 0)
                    {
                        v = CrossPlatformInputManager.GetAxis("Horizontal");
                        h = CrossPlatformInputManager.GetAxis("Vertical");
                        crouch = Input.GetKey(KeyCode.Space);
                    }

                    if (Confused_count == 1)
                    {
                        h = CrossPlatformInputManager.GetAxis("Horizontal"); 
                        v = CrossPlatformInputManager.GetAxis("Vertical");
                        crouch = Input.GetKey(KeyCode.C);
                    }

                    if (Confused_count == 3)
                    {
                        h = CrossPlatformInputManager.GetAxis("Horizontal");
                        h = CrossPlatformInputManager.GetAxis("Vertical");
                        crouch = Input.GetKey(KeyCode.Space);
                    }

                    if (Confused_count == 4)
                    {
                        v = CrossPlatformInputManager.GetAxis("Horizontal");
                        v = CrossPlatformInputManager.GetAxis("Vertical");
                        crouch = Input.GetKey(KeyCode.C);
                    }

                } else
                {
                    h = CrossPlatformInputManager.GetAxis("Horizontal");
                    v = CrossPlatformInputManager.GetAxis("Vertical");
                    crouch = Input.GetKey(KeyCode.C);

                }



                // calculate move direction to pass to character
                if (m_Cam != null)
                {
                    // calculate camera relative direction to move:
                    m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                    m_Move = v * m_CamForward + h * m_Cam.right;
                }
                else
                {
                    // we use world-relative directions in the case of no main camera
                    m_Move = v * Vector3.forward + h * Vector3.right;
                }
#if !MOBILE_INPUT
                // walk speed multiplier
                if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

                // pass all parameters to the character control script
                m_Character.Move(m_Move, crouch, m_Jump);
                m_Jump = false;
            }
        }

    }

    
}
