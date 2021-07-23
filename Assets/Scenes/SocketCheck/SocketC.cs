using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class SocketC : MonoBehaviour
{
    Thread mThread;

    //Ip address of PI
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 8052;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    Vector3 receivedPos = Vector3.zero;

    bool running;

    private void Update()
    {

    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
       // mThread.IsBackground = true;
        mThread.Start();
    }

    void GetInfo()
    {
        print("Server has started!!!!!!1");
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        print("Client accepted!");
        while (running)
        {
            
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //---receiving Data from the Host----
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Getting data in Bytes from Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Converting byte data to string
        if (dataReceived != null)
        {
            // making the boy jump
            print("We are jumping yayyy!!" );
            boy.jump = true;

        }
    }
    
}
