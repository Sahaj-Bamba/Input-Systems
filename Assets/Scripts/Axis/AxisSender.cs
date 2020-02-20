using UnityEngine;
using System.Net;
using System.Net.Sockets;
using TMPro;
using System.Text;

public class AxisSender : MonoBehaviour
{
    private IPEndPoint anyIP;
    private UdpClient client;
    private int port=9875;
    private TextMeshProUGUI msg;

    void Start()
    {
        anyIP = new IPEndPoint(IPAddress.Any, port);
        client = new UdpClient();
    }

    public void send(){

        AxisData axisData = new AxisData(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        msg.text = axisData.ToString();
        string st = JsonUtility.ToJson(axisData);
        byte[] data = Encoding.UTF8.GetBytes(st); 
        client.Send(data, data.Length, anyIP);

    }

    private void FixedUpdate() {
        send();
    }

}
