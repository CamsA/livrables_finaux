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
        private Socket listener;

        // Port used by the connexion
        int remotePort = 11011;

        // Incoming data from the client
        public string data = null;

        // Buffer for incoming data
        byte[] bytes = new Byte[2048];


        // Constructor of the server socket class
        public KitchenListenerSocket()
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

                // Show the data on the console.  
                Console.WriteLine("Text received : {0}", data);

                this.SendMessage("Message Received : " + data);

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

        // Read the message and start differents actions according to the content
        private void HandleMessage(String msg)
        {
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;

            // Show the data on the console
            Console.WriteLine("\nMessage received : " + msg);

            string[] splittedMsg = msg.Split(':', '<', '>');

            int number;
            int.TryParse(splittedMsg[1], out number);

            switch (splittedMsg[0])
            {
                case "DN":
                    Console.Write("\nServiette(s) sale(s) : " + number);
                    exchangeDesk.AddDirtyObject("Napkins", number);
                    break;
                case "DTC":
                    Console.Write("\nNappe(s) de table sale(s) : " + number);
                    exchangeDesk.AddDirtyObject("TableClothes", number);
                    break;
                case "DC":
                    Console.Write("\nPlat(s) sale(s) : " + number);
                    exchangeDesk.AddDirtyObject("Crockery", number);
                    break;
                case "NO":
                    Console.Write("\nUne commande a été passée pour le plat à l'ID " + number);
                    exchangeDesk.AddWaitingOrder(number);
                    break;
                default:
                    Console.Write("\nCannot Recognize Message");
                    break;
            }
        }

        public void CloseSocket()
        {
            this.handler.Shutdown(SocketShutdown.Both);
            this.handler.Close();
        }
    }
}
