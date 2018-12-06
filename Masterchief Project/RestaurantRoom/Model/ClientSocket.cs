using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RestaurantRoom.Model
{
    class ClientSocket
    {
        private Socket sender;
        private byte[] bytes = new byte[1024];

        private String message = "This is a test<EOF>";

        public void StartClient()
        {

            try
            {
                // Connect to a Remote server  
                // Get Host IP Address that is used to establish a connection  
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                // If a host has multiple addresses, you will get a list of addresses  
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.    
                this.sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    this.sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        this.sender.RemoteEndPoint.ToString());

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

        public void SendMessage(String message)
        {
            // Encode the data string into a byte array.    
            byte[] msg = Encoding.ASCII.GetBytes(message);

            // Send the data through the socket.    
            int bytesSent = this.sender.Send(msg);

            // Receive the response from the remote device.    
            int bytesRec = this.sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));
        }

        public void CloseSockets()
        {
            // Release the socket.    
            this.sender.Shutdown(SocketShutdown.Both);
            this.sender.Close();
        }
    }
}
