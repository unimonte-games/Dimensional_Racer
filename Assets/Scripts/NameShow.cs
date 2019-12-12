using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class NameShow : MonoBehaviour
{

    public TextMeshProUGUI Name;

    [PunRPC]
    public void updateName(string name)
    {
        Name.text = name;
    }


}
