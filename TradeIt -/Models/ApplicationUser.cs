using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradeIt__.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Portofolio Portofolio { get; set; }
    }
}
