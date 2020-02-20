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

    private int sti(string st){
		int r = 0;
		int i=0;
		int n = st.Length;
		foreach (var ch in st)
		{
			i++;
			if(i==n){
				break;
			}
			r *=10;
			r += (ch-'0');
		}
		return r;
	}

    // private string tmtext(string st){
    //     int n = st.Length;
    //     string rs;
    //     for (int i = 0; i < n; i++)
    //     {
    //         rs = st[i] + rs;
    //     }
    // }

    void Start()
    {
        Debug.Log(ip.text.Split('$')[0]);
        if(ip.text == "Any"){
            anyIP = new IPEndPoint(IPAddress.Any, sti(port.text));
        }else{
            anyIP = new IPEndPoint(IPAddress.Parse(ip.text.Split('$')[0]), sti(port.text));
        }    
        client = new UdpClient();
    }

    public void send(){

        byte[] data = Encoding.UTF8.GetBytes(msg.text); 
        client.Send(data, data.Length, anyIP);

    }

}
