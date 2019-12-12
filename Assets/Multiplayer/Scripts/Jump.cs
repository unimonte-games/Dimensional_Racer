using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    private PhotonView PV;

    int Value1;
    int Value2;
    int Value3;


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();

    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (PV.IsMine)
        {

            if (other.gameObject.tag == "JumpJacks")
            {
                Value1 = other.GetComponent<JumpingJacks>().X;
                Value2 = other.GetComponent<JumpingJacks>().Y;
                Value3 = other.GetComponent<JumpingJacks>().Z;

                PV.RPC("Jumping_RPC", RpcTarget.All);
                


            }
        }
        

    }

    [PunRPC]
    void Jumping_RPC()
    {
        rb.velocity = new Vector3(Value1, Value2, Value3);
    }

}
