using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class Portofolio
    {

        [Key]
        public int PortofolioId { get; set; }

        public String UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public virtual ICollection<Balance> Balances { get; set; }

    }
}
