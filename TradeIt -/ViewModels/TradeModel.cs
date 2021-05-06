using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.ViewModels
{
    public class TradeModel : PortofolioModel
    {
        public List<Currency> currencies { get; internal set; }

        public List<ExchangeRate> exchangeRates { get; internal set;}

        public int? currencyId;
        
    }
}
