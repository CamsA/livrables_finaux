using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace Kitchen.Model
{
    class KitchenListenerSocket
    {
        private Socket handler;

        // Incoming data from the client
        public string data = null;

        // Buffer for incoming data
        byte[] bytes = new Byte[2048];

        

        // Constructor of the server socket class
        public KitchenListenerSocket()
        {
            // Set the initializing parameters of the socket
            int remotePort = 11000;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, remotePort);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Connect to the EndPoint
                listener.Bind(localEndPoint);

                // Start listening for connections
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");

                // Program is suspended while waiting for an incoming connection.  
                Socket handler = listener.Accept();
                data = null;

                StartListening();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        public void StartListening()
        {
            while (true)
            {
                while (true)
                {
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOM>") > -1)
                    {
                        break;
                    }
                }

                // Show the data on the console.  
                Console.WriteLine("Text received : {0}", data);

                SendMessage("Message Received");
            }
        }

        public void SendMessage(String message)
        {
            try
            {
                // Encode the data string into a byte array
                byte[] msg = Encoding.ASCII.GetBytes(message + "<EOM>");

                // Send the data
                int bytesSent = handler.Send(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void CloseSocket()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
