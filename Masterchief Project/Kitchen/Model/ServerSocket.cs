using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Kitchen.Model
{
    class ServerSocket
    {
        private string data = null;
        private byte[] bytes = null;

        private Socket handler;


        // Initialize the Sender with parameters
        public void InitializeSender()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            try
            {

                // Create a Socket that will use Tcp protocol      
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                this.handler = listener.Accept();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            this.StartListening();
        }

        // Start listening to RestaurantRoom messages
        private void StartListening()
        {
            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = this.handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            byte[] msg = Encoding.ASCII.GetBytes(data);
            this.handler.Send(msg);
        }

        // Sends cleaned objects (napkins and table clothes) to the Restaurant Room stcok (in Exchange Desk)
        private void SendCleanObjects(String type, int number)
        {
            // TODO
        }

        // Sends prepared meals to the Restaurant Room Exchange Desk
        private void SendPreparedMeals(List<Meal> mealList)
        {
            // TODO
        }

        // We maybe able to use delegates on these function
        // Sends message via the socket
        private void SendMessage()
        {

        }

        public void CloseSockets()
        {
            this.handler.Shutdown(SocketShutdown.Both);
            this.handler.Close();
        }
    }
}
