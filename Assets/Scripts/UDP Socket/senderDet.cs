using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senderDet : MonoBehaviour
{
   
    public GameObject sender;

    public void sendStart(){
        sender.SetActive(true);
        gameObject.SetActive(false);
    }

}
