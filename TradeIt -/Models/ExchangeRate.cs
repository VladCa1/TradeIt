using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class ExchangeRate
    {
        [Key]
        public int ExchangeRateId { get; set; }

        public int CurrencyId { get; set; }

        public float Rate { get; set; }

        public ExchangeRate()
        {
            
        }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}
