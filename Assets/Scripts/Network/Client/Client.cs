using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Client
{
    public static TcpClient TcpSocket;
    public static UdpClient UdpSocket;

    private ServerListener _serverListener;


    public static int port = 8052; 

    public Client()
    {
        Init();
    }

    private void Init()
    {
        Thread connectionThread = new Thread(new ThreadStart(MakeConnection));
        connectionThread.IsBackground = true;
        connectionThread.Start();       
    }

    private void MakeConnection()
    {
        TcpSocket = new TcpClient("127.0.0.1", port);
        _serverListener = new ServerListener();
    }

    private void Send(string msg)
    {

    }
}
