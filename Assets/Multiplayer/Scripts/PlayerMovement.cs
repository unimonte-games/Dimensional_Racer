using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{ 

    public float moveSpeed;

// Use this for initialization
void Start()
{

    moveSpeed = 10f;

}

// Update is called once per frame
void Update()
{

    transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

}
}


 