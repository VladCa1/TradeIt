using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        public String Name { get; set; }

        public Currency(String Name)
        {
            this.Name = Name;
        }

        public ExchangeRate ExchangeRate { get; set; }
    }
}
