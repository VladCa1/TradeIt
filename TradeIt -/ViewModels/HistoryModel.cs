using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.ViewModels
{
    public class HistoryModel
    {
        public ICollection<Models.History> Histories { get; set; }

        public string UserId { get; set; }

        public HistoryModel(ICollection<History> histories)
        {
            Histories = histories;
        }
    }
}
