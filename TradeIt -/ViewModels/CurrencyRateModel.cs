using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.ViewModels
{
    public class CurrencyRateModel
    {
        public Currency Currency { get; set; }
        public ExchangeRate ExchangeRate { get; set; }
    }
}
