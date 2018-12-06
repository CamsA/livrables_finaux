using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Receiver
    {



        // Start the listening thread
        private void StartListening()
        {
            Thread listeningThread = new Thread(ListeningThread);


        }


        // Thread listening to the socket to get messages.
        private void ListeningThread()
        {

        }

        // Initialize the connexion with the 
    }
}

