using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<History> SendTransactions { get; set; }
        public ICollection<History> ReceiveTransactions { get; set; }
        public Portofolio Portofolio { get; set; }
    }
}
