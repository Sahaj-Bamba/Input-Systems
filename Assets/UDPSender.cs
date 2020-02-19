using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using TMPro;
using System.Text;

public class UDPSender : MonoBehaviour
{
    // Start is called before the first frame update

    private IPEndPoint anyIP;
    private UdpClient client;
    public TextMeshProUGUI ip;
    public TextMeshProUGUI port;
    public TextMeshProUGUI msg;

    void Start()
    {
        if(ip.text == "Any"){
            anyIP = new IPEndPoint(IPAddress.Parse(ip.text), int.Parse(port.text));
        }else{
            anyIP = new IPEndPoint(IPAddress.Any, int.Parse(port.text));
        }    
        client = new UdpClient();
    }

    public void send(){

        byte[] data = Encoding.UTF8.GetBytes(msg.text); 
        client.Send(data, data.Length, anyIP);

    }

}
