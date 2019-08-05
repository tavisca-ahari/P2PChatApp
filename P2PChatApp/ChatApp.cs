using System;

namespace P2PChatApp
{
    public class ChatApp
    { 

        public void StartChat()
        {
            Message message = new Message();
            try
            {
                Console.WriteLine("hello");
                NetworkClient networkClient = new NetworkClient();
                networkClient.Connect();
                networkClient.OnNewConnection(message);
            }
            catch (Exception)
            {
                NetworkListener networkListener = new NetworkListener();
                networkListener.StartListening();
                networkListener.OnNewConnection(message);
            }
        }
    }
}