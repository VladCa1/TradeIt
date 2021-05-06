using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.Models
{
    public class Balance
    {

        [Key]
        public int BalanceId { get; set; }

        public int PortofolioId { get; set; }

        public int CurrencyId { get; set; }

        public float Amount { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        [ForeignKey("PortofolioId")]
        public Portofolio Portofolio { get; set; }



    }
}
