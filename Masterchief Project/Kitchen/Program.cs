using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitchen.Model;
using System.Threading;

namespace Kitchen
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new kitchenForm());

            KitchenListenerSocket kls = new KitchenListenerSocket();
            Thread.Sleep(5000);
            KitchenClientSocket kss = new KitchenClientSocket();
            kss.SendMessage("Test.<EOM>");
            kls.CloseSocket();
            kss.CloseSocket();

        }
    }
}
