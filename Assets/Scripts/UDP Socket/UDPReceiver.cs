﻿using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;

public class UDPReceiver : MonoBehaviour
{

    private Thread receiveThread;
	private UdpClient client;
    private GameObject Manager;
    private string action;
	
	public TextMeshProUGUI ip;
	public TextMeshProUGUI port;
	
	private IPEndPoint anyIP;

    void Start()
    {
        Manager = GameObject.Find("GameManager");
    }

	public void startUDP(){
		InitUDP(); 
	}

    private void InitUDP()
	{
		print ("UDP Initialized");

		client = new UdpClient (int.Parse(port.text));		
		if(ip.text == "Any"){
			anyIP = new IPEndPoint(IPAddress.Parse(ip.text), int.Parse(port.text));
		}else{
			anyIP = new IPEndPoint(IPAddress.Any, int.Parse(port.text));
		}
		
		receiveThread = new Thread (new ThreadStart(ReceiveData)); 
		receiveThread.IsBackground = true;
		receiveThread.Start ();

	}

	//	Receive Data and set to action
	private void ReceiveData()
	{
		while (true)
		{
			byte[] data = client.Receive(ref anyIP);
			string text = Encoding.UTF8.GetString(data);
			action = text;
			Debug.Log(text);
		}
	}

    void Update(){
        if (action != "")
        {
        	Manager.GetComponent<UDPHandller>().action = action;    
			action = "";
		}
	}
    
}
