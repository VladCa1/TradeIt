using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.ViewModels
{
    public class SellModel
    {
        public Balance balance { get; internal set; }
        public ExchangeRate exchangeRate { get; internal set; }
        public string balanceName { get; internal set; }
    }
}
