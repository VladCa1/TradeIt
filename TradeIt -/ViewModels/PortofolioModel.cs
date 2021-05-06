using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.ViewModels
{
    public class PortofolioModel
    {
        public List<Models.Balance> balances;
        public List<string> balanceNames;
        public PortofolioModel()
        {
            balances = new List<Models.Balance>();
            balanceNames = new List<string>();
        }

    }
}
