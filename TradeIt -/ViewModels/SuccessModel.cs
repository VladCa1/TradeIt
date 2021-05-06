using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.ViewModels
{
    public class SuccessModel
    {
        public string action { get; set; }
        public SuccessModel(string action)
        {
            this.action = action;
        }
    }
}
