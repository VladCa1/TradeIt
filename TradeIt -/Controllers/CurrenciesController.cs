using Microsoft.AspNetCore.Authorization;
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
    public class CurrenciesController : Controller
    {

        private readonly ICurrencyService currenciesService;
        private readonly IExchangeRateService exchangeRateService;

        public CurrenciesController(ICurrencyService currenciesService, IExchangeRateService exchangeRateService)
        {
            this.currenciesService = currenciesService;
            this.exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Currencies = currenciesService.GetAllCurrencies();
            return View(Currencies);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Currency Currency)
        {
            if(Currency != null)
            currenciesService.CreateCurrency(Currency.Name);
            return RedirectToAction("Index", "Currencies");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Currency = currenciesService.ReadCurrency(id);
            var ExchangeRate = exchangeRateService.ReadExchangeRate(id);

            var CurrencyRateModel = new CurrencyRateModel();
            CurrencyRateModel.Currency = Currency;
            CurrencyRateModel.ExchangeRate = ExchangeRate;

            return View(CurrencyRateModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toDelete = currenciesService.ReadCurrency((int)id);
            return View(toDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            currenciesService.DeleteCurrency(id);
            return RedirectToAction("Index", "Currencies");
        }



    }
}
