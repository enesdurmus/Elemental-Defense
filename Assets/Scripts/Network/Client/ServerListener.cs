using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ServerListener
{
    Thread receiveThread;

    public ServerListener()
    {
        receiveThread = new Thread(new ThreadStart(Run));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void Run()
    {
        while (true)
        {
            try
            {
                Byte[] bytes = new Byte[1024];
                while (true)
                {
                    // Get a stream object for reading 				
                    using (NetworkStream stream = Client.TcpSocket.GetStream())
                    {
                        int length;
                        // Read incomming stream into byte arrary. 					
                        while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            var incommingData = new byte[length];
                            Array.Copy(bytes, 0, incommingData, 0, length);
                            // Convert byte array to string message. 						
                            string serverMessage = Encoding.ASCII.GetString(incommingData);
                            Debug.Log("server message received as: " + serverMessage);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }
}