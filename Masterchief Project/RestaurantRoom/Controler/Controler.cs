using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantRoom
{
    public class Controler
    {

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Aaaa");
            Model model = new Model();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View());
        }

        public Controler()
        {
            Console.WriteLine("bbb");
        }
    }
}
