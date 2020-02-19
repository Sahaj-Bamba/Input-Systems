using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject sender;
    public GameObject receiver;

    public void sendStart(){
        sender.SetActive(true);
        gameObject.SetActive(false);
    }
    public void receiveStart(){
        receiver.SetActive(true);
        gameObject.SetActive(false);
    }

}
