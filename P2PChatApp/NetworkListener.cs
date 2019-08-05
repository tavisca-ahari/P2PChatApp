using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace P2PChatApp
{
    public class NetworkListener
    {
        Socket handler;
        public void StartListening()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            listener.Bind(ipEnd);
            listener.Listen(10);
            handler = listener.Accept();

        }
        public void OnNewConnection(Message message)
        {
            Console.WriteLine("Connected");
            Console.WriteLine("Start chatting...");
            Conversation conversation = new Conversation();
            Thread threadWrite = new Thread(() => conversation.Write(handler, message));
            Thread threadRead = new Thread(() => conversation.Receive(handler));
            threadWrite.Start();
            threadRead.Start();
        }
    }
}