using UnityEngine;
using TMPro;

public class Receive : MonoBehaviour
{
    public bool isActive;
    private string action;
    private GameObject Manager;
    public TextMeshProUGUI msg;

    void Start()
    {
        Manager = GameObject.Find("GameManager");
        Debug.Log("Receive Start");
        Activate();
    }

    public void Activate(){
        isActive = true;
    }
    
    void FixedUpdate()
    {
        if (isActive)
        {
            action = Manager.GetComponent<UDPHandller>().action;
			Manager.GetComponent<UDPHandller>().action = null;
            if (action == "" || action == null)
            {
                return;
            }
            else {
                Add(action);
            }
        }
    }

    private void Add(string str){
        msg.text += str + "/n";
    }

}

