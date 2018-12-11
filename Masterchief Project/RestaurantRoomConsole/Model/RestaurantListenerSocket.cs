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

        // Launch the loop of listening to incoming data
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

                // Reset the string holding the message
                data = null;
            }
        }

        // Method used to send a message to the connected Client
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
            // Get access to the ExchangeDesk instance
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;

            // Show the data on the console
            Console.WriteLine("\nMessage received : " + msg);

            // Split the message to get the infos
            string[] splittedMsg = msg.Split(':', '<', '>');

            // Convert the number from string to integer
            int number;
            int.TryParse(splittedMsg[1], out number);

            // Choose the action to lead according to the code read in the message
            // "CN" == "Clean Napkins", "CTC" == "Clean Table Clothes", "RM" == "Ready Meal"
            switch (splittedMsg[0])
            {
                case "CN":
                    Console.Write("\nServiette(s) propre(s) : " + number);
                    exchangeDesk.AddCleanObject("Napkins", number);
                    break;
                case "CTC":
                    Console.Write("\nNappe(s) de table propre(s) : " + number);
                    exchangeDesk.AddCleanObject("TableClothes", number);
                    break;
                case "RM":
                    Console.Write("\nC'est un plat qui a l'ID : " + number);
                    exchangeDesk.AddPreparedMeal(number);
                    break;
                default:
                    Console.Write("\nCannot Recognize Message");
                    break;
            }
        }

        // Close the socket
        public void CloseSocket()
        {
            this.handler.Shutdown(SocketShutdown.Both);
            this.handler.Close();
        }
    }
}
