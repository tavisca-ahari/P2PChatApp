using System;
using System.Net.Sockets;
using System.Text;

namespace P2PChatApp
{
    public class Conversation
    {
        Display display = new Display();
        public void Write(Socket handler, Message message)
        {
            while (true)
            {
                
                message.Text = Console.ReadLine();
               

                byte[] msg = Encoding.ASCII.GetBytes(message.Text);
                int bytesSent = handler.Send(msg);
            }
        }
        public void Receive(Socket handler)
        {
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesReceived = handler.Receive(bytes);
                    string message = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
                    display.ShowRecievedMessage(message);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}