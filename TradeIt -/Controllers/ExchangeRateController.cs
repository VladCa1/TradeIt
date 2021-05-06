using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;
using TradeIt__.Services;
using TradeIt__.ViewModels;

namespace TradeIt__.Controllers
{
    public class ExchangeRateController : Controller
    {

        private readonly IExchangeRateService exchangeRateService;
        private readonly ICurrencyService currencyService;

        public ExchangeRateController(IExchangeRateService exchangeRateService, ICurrencyService currencyService)
        {
            this.exchangeRateService = exchangeRateService;
            this.currencyService = currencyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var holder = new Holder(id);
            return View(holder);
        }

        public IActionResult AddExchangeRate(float rate, int currencyId)
        {
            exchangeRateService.CreateExchangeRate(currencyService.ReadCurrency(currencyId), rate);
            return RedirectToAction("Details", "Currencies", new { id = currencyId});
        }

 
        public IActionResult Update(int id)
        {
            var toUpdate = exchangeRateService.ReadExchangeRate(id);

            return View(toUpdate);
            
        }

        [HttpPost]
        public IActionResult Update(ExchangeRate exchangeRate)
        {
            var rate = exchangeRate.Rate;
            var id = exchangeRate.CurrencyId;
            exchangeRateService.UpdateExchangeRate(rate, id);
            return RedirectToAction("Details", "Currencies", new { id = id });
        }

    }

}
