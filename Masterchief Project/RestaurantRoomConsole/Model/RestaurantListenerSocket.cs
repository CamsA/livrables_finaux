using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RestaurantRoomConsole.Model
{
    class RestaurantListenerSocket
    {
        private Socket handler;
        private Socket listener;

        // Port used by the connexion
        private int remotePort = 11010;

        // Incoming data from the client
        public string data = null;

        // Buffer for incoming data
        byte[] bytes = new Byte[2048];


        // Constructor of the server socket class
        public RestaurantListenerSocket()
        {
            // Set the initializing parameters of the socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, this.remotePort);

            // Create a TCP/IP socket.  
            this.listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Connect to the EndPoint
                this.listener.Bind(localEndPoint);

                // Start listening for connections
                this.listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");

                // Program is suspended while waiting for an incoming connection
                this.handler = listener.Accept();
                this.data = null;

                this.StartListening();

            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                Console.Read();
            }
        }

        public void StartListening()
        {
            while (true)
            {
                while (true)
                {
                    int bytesRec = this.handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOM>") > -1)
                    {
                        break;
                    }
                }

                // Send the confirmation to the other socket that the message has been received
                this.SendMessage("Message Received : " + data);

                // Handle the message
                this.HandleMessage(data);

                data = null;
            }
        }

        public void SendMessage(String message)
        {
            try
            {
                // Encode the data string into a byte array
                byte[] msg = Encoding.ASCII.GetBytes(message + "<EOM>");

                // Send the data
                int bytesSent = this.handler.Send(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void CloseSocket()
        {
            this.handler.Shutdown(SocketShutdown.Both);
            this.handler.Close();
        }

        // Read the message and start differents actions according to the content
        private void HandleMessage(String msg)
        {
            ExchangeDesk.GetInstance

            // Show the data on the console
            Console.WriteLine("Message received : " + msg);

            string[] processedData = msg.Split(':', '>', '<');

            switch (StrOK[0])
            {
                case "CN":
                    Console.Write("Serviette(s) propre(s)");
                    Console.Write(" : " + StrOK[1]);
                    break;
                case "CTC":
                    Console.Write("Nappe(s) de table propre(s)");
                    Console.Write(" : " + StrOK[1]);
                    break;
                case "RM":
                    Console.Write("C'est un repas");
                    Console.Write("Le repas a l'ID : " + StrOK[1]);
                    break;
                default:
                    Console.Write("Cannot Recognize");
                    break;
            }



        }
    }
}
