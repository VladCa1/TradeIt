using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Services;

namespace TradeIt__.Controllers
{
    public class FunctionsController : Controller
    {

        private readonly ICurrencyService currencyService;

        public IActionResult Index()
        {
            return View();
        }
      

    }
}
