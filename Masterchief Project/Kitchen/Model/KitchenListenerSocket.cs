using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Kitchen.Model
{
    static class KitchenListenerSocket
    {
        public static Socket handler;
        public static Socket listener;

        // Port used by the connexion
        private static int remotePort = 11011;

        // Incoming data from the client
        private static string data = null;

        // Buffer for incoming data
        private static byte[] bytes = new Byte[2048];


        // Constructor of the server socket class
        public static void Initialize()
        {
            // Set the initializing parameters of the socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, remotePort);

            // Create a TCP/IP socket.  
            listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Connect to the EndPoint
                listener.Bind(localEndPoint);

                // Start listening for connections
                listener.Listen(10);

                View.Display.DisplayMsg("Cuisine en attente d'un signal de la salle de restauration", false, false, ConsoleColor.DarkYellow);

                // Program is suspended while waiting for an incoming connection
                handler = listener.Accept();
                data = null;

                StartListening();

            }
            catch (Exception e)
            {
                View.Display.DisplayMsg("Erreur lors de l'établissement de l'échange entre la cuisine et la salle : " + e.ToString(), false, true, ConsoleColor.Red);
                Console.Read();
            }
        }

        // Launch the loop of listening to incoming data
        public static void StartListening()
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

                // Send the confirmation to the other socket that the message has been received
                SendMessage("Message Received : " + data);

                // Handle the message
                HandleMessage(data);

                // Reset the string holding the message
                data = null;
            }
        }

        // Method used to send a message to the connected Client
        public static void SendMessage(String message)
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
                View.Display.DisplayMsg("Erreur lors de la réponse à un message de la salle : " + message + "\n" + e.ToString(), false, true, ConsoleColor.Red);
            }
        }

        // Read the message and start differents actions according to the content
        private static void HandleMessage(String msg)
        {
            // Get access to the ExchangeDesk instance
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;

            // Show the data on the console
            // Console.WriteLine("\nMessage received : " + msg);

            // Split the message to get the infos
            string[] splittedMsg = msg.Split(':', '<', '>');

            // Convert the number from string to integer
            int number;
            int.TryParse(splittedMsg[1], out number);

            // Choose the action to lead according to the code read in the message
            // "DN" == "Dirty Napkins", "DTC" == "Dirty Table Clothes", "DC" == "Dirty Crockery", "NO" == "New Order"
            switch (splittedMsg[0])
            {
                case "DN":
                    View.Display.DisplayMsg("Serviette(s) sale(s) reçue(s) de la salle : " + number, false, false, ConsoleColor.DarkYellow);
                    exchangeDesk.AddDirtyObject("Napkins", number);
                    break;
                case "DTC":
                    View.Display.DisplayMsg("Nappe(s) de table sale(s) reçue(s) de la salle : " + number, false, false, ConsoleColor.DarkYellow);
                    exchangeDesk.AddDirtyObject("TableClothes", number);
                    break;
                case "DC":
                    View.Display.DisplayMsg("Plat(s) sale(s) reçu(s) de la salle : " + number, false, false, ConsoleColor.DarkYellow);
                    exchangeDesk.AddDirtyObject("Crockery", number);
                    break;
                case "NO":
                    View.Display.DisplayMsg("Une commande a été passée pour le plat à l'ID " + number, false, false, ConsoleColor.DarkYellow);
                    exchangeDesk.AddWaitingOrder(number);
                    break;
                default:
                    View.Display.DisplayMsg("Message incompréhensible en provenance de la salle : " + number, false, false, ConsoleColor.Red);
                    break;
            }
        }

        // Close the socket
        public static void CloseSocket()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
