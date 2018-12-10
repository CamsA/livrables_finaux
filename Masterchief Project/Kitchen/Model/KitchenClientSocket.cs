using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Kitchen.Model
{
    class KitchenClientSocket
    {
        private Socket sender;
        private byte[] bytes = new byte[2048];







        // Constructor of the client socket class
        public KitchenClientSocket()
        {
            // Set the initializing parameters of the socket
            int remotePort = 11000;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, remotePort);

            // Create the client socket
            Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        public void SendMessage(String message)
        {
            // Encode the data string into a byte array
            byte[] msg = Encoding.ASCII.GetBytes(message + "<EOM>");

            // Send the data
            int bytesSent = sender.Send(msg);

            // Receive the answer
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));
        }

        public void CloseSocket()
        {
            // Release the socket 
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
