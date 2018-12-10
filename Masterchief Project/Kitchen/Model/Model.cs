using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    class Model
    {
        public int clock;
        Kitchen kitchen = Kitchen.GetInstance;
        ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
    }
}
