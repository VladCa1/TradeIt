using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public float Amount { get; set; }

        public string CurrencyId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public History(float Amount, string CurrencyId, DateTime Date, string SenderId, string ReceiverId)
        {
            this.Amount = Amount;
            this.CurrencyId = CurrencyId;
            this.Date = Date;
            this.SenderId = SenderId;
            this.ReceiverId = ReceiverId;
        }
    }
}
