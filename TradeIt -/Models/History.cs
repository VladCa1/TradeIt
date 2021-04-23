using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }

        public float Amount { get; set; }

        public int CurrencyId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }

        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public History(float Amount, int CurrencyId, DateTime Date, string SenderId, string ReceiverId)
        {
            this.Amount = Amount;
            this.CurrencyId = CurrencyId;
            this.Date = Date;
            this.SenderId = SenderId;
            this.ReceiverId = ReceiverId;
        }
    }
}
