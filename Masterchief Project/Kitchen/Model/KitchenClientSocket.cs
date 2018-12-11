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

        // Port used by the connexion
        int remotePort = 11010;

        // Buffer for incoming data
        private byte[] bytes = new byte[2048];

        // Constructor of the client socket class
        public KitchenClientSocket()
        {
            // Set the initializing parameters of the socket
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, this.remotePort);

            // Create the client socket
            this.sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

            // Connect the client socket
            try
            {
                this.sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}\n",
                    this.sender.RemoteEndPoint.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                Console.Read();
            }
        }

        // Function used to send the messages
        public void SendMessage(String message)
        {
            try
            {
                // Encode the data string into a byte array
                byte[] msg = Encoding.ASCII.GetBytes(message + "<EOM>");

                // Send the data
                this.sender.Send(msg);

                // Receive the answer
                int bytesRec = this.sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                Console.Read();
            }
        }

        // Used to close the socket
        public void CloseSocket()
        {
            try
            {
                // Release the socket 
                this.sender.Shutdown(SocketShutdown.Both);
                this.sender.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                Console.Read();
            }
        }
    }
}
