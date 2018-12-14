using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RestaurantRoomConsole.Model
{
    static class RestaurantClientSocket
    {
        public static Socket sender;

        // Port used by the connexion
        private static int remotePort = 11011;

        // Buffer for incoming data
        private static byte[] bytes = new byte[2048];

        // Constructor of the client socket class
        public static void Initialize()
        {
            // Set the initializing parameters of the socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, remotePort);

            // Create the client socket
            sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

            Thread.Sleep(5000);

            // Connect the client socket
            try
            {
                sender.Connect(remoteEP);

                View.Display.DisplayMsg("La salle à ouvert le comptoir d'échange avec la cuisine (" + sender.RemoteEndPoint.ToString() + ")", false, true, ConsoleColor.Yellow);


            }
            catch (Exception e)
            {
                View.Display.DisplayMsg("Erreur lors de l'établissement de l'échange entre la salle et la cuisine : " + e.ToString(), false, true, ConsoleColor.Red);
                Console.Read();
            }
        }

        // Function used to send the messages
        public static void SendMessage(String message)
        {
            try
            {
                // Encode the data string into a byte array
                byte[] msg = Encoding.ASCII.GetBytes(message + "<EOM>");

                // Send the data
                sender.Send(msg);

                // Receive the answer
                int bytesRec = sender.Receive(bytes);
                //Console.WriteLine("Echoed test = {0}",
                //    Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
            catch (Exception e)
            {
                View.Display.DisplayMsg("Erreur lors de l'envoi d'un message à la cuisine : " + message + "\n" + e.ToString(), false, true, ConsoleColor.Red);
                Console.Read();
            }
        }

        // Used to close the socket
        public static void CloseSocket()
        {
            try
            {
                // Release the socket 
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                View.Display.DisplayMsg("Erreur lors de la fermeture du socket : " + e.ToString(), false, true, ConsoleColor.Red);
                Console.Read();
            }
        }
    }
}
