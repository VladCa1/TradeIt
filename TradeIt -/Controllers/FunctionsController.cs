using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeIt__.Services;
using TradeIt__.ViewModels;

namespace TradeIt__.Controllers
{
    [Authorize]
    public class FunctionsController : Controller
    {

        public const string EUR = "EUR";
        public const int EUR_ID = 2;

        private readonly IAccountService accountService;
        private readonly ICurrencyService currencyService;
        private readonly IFunctionsService functionsService;
        private readonly IHistoryService historyService;
        private readonly IExchangeRateService exchangeRateService;

        public FunctionsController(IAccountService accountService,
            ICurrencyService currencyService,
            IFunctionsService functionsService,
            IHistoryService historyService,
            IExchangeRateService exchangeRateService)
        {
            this.accountService = accountService;
            this.currencyService = currencyService;
            this.functionsService = functionsService;
            this.historyService = historyService;
            this.exchangeRateService = exchangeRateService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [Route("/Transfer")]
        public IActionResult Transfer()
        {
            var transferModel = new TransferModel();

            transferModel.balances = accountService.GetAccountBalances(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            foreach (var item in transferModel.balances)
            {
                transferModel.balanceNames.Add(currencyService.ReadCurrency(item.CurrencyId).Name);
            }

            return View(transferModel);
        }

        [Route("/Donate")]
        public IActionResult Donate()
        {
            var donateModel = new DonateModel();

            return View(donateModel);
        }

        [Route("/Trade/{currencyId?}")]
        public IActionResult Trade(int? currencyId)
        {
            var tradeModel = new TradeModel();

            AddForAccount(tradeModel);

            if(currencyId != null)
            {
                tradeModel.currencyId = currencyId;
            }

            tradeModel.currencies = currencyService.GetAllCurrencies();
            tradeModel.exchangeRates = new List<Models.ExchangeRate>(); 
            foreach (var item in tradeModel.currencies)
            {
                tradeModel.exchangeRates.Add(exchangeRateService.ReadExchangeRate(item.CurrencyId));
            }

            return View(tradeModel);
        }

        [HttpPost]
        public IActionResult PostTrade(string currency, float toReceive, float toSpend)
        {

            if (!accountService.IsValidBalance(this.User.FindFirstValue(ClaimTypes.Name), EUR, toSpend))
            {
                return RedirectToAction("Failure", new { errorType = "funds" });
            }

            functionsService.AddToAccount(this.User.FindFirstValue(ClaimTypes.Name), currency, toReceive);
            functionsService.DedudctFromAccount(this.User.FindFirstValue(ClaimTypes.Name), EUR, toSpend);
            historyService.AddHistoryEntry(this.User.FindFirstValue(ClaimTypes.NameIdentifier), "9999999", DateTime.Now, EUR, toSpend);
            historyService.AddHistoryEntry("9999999", this.User.FindFirstValue(ClaimTypes.NameIdentifier), DateTime.Now, currency, toReceive);

            return RedirectToAction("Success", new { actionType = "Trade" });
        }

        [HttpPost]
        public IActionResult PostTransfer(string currency, string username, float amount)
        {
            if (!accountService.IsValidUsername(username) && (username == this.User.FindFirstValue(ClaimTypes.Name)))
            {
                return RedirectToAction("Failure", new { errorType = "username" });
            }
            if (!accountService.IsValidBalance(this.User.FindFirstValue(ClaimTypes.Name), currency, amount))
            {
                return RedirectToAction("Failure", new { errorType = "funds" });
            }

            functionsService.AddToAccount(username, currency, amount);
            functionsService.DedudctFromAccount(this.User.FindFirstValue(ClaimTypes.Name), currency, amount);
            historyService.AddHistoryEntry(this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                accountService.GetUserIdForUsername(username), DateTime.Now, currency, amount);

            return RedirectToAction("Success", new { actionType = "Transfer" });
        }

        public void AddForAccount(PortofolioModel model)
        {
            model.balances = accountService.GetAccountBalances(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            foreach (var item in model.balances)
            {
                model.balanceNames.Add(currencyService.ReadCurrency(item.CurrencyId).Name);
            }
        }

        public ActionResult Success(string? actionType)
        {
            return View(new SuccessModel(actionType));
        }

        public ActionResult Failure(string? errorType)
        {
            return View(new FailureModel(errorType));
        }

        public IActionResult Sell(int? id)
        {

            var sellModel = new SellModel();

            var balance = accountService.GetAccountBalance(this.User.FindFirstValue(ClaimTypes.NameIdentifier), (int)id);
            if (balance == null || id == null || id == EUR_ID)
            {
                return RedirectToAction("Index","Home");
            }

            sellModel.balance = balance;
            sellModel.balanceName = currencyService.ReadCurrency((int)id).Name;
            sellModel.exchangeRate = exchangeRateService.ReadExchangeRate((int)id);
            return View(sellModel);
        }

        [HttpPost]
        public IActionResult PostSell(float amount, int id)
        {
            functionsService.DedudctFromAccount(this.User.FindFirstValue(ClaimTypes.Name), currencyService.ReadCurrency(id).Name, amount);
            historyService.AddHistoryEntry(this.User.FindFirstValue(ClaimTypes.NameIdentifier), "9999999", DateTime.Now, currencyService.ReadCurrency(id).Name ,amount);
            amount = functionsService.ConvertToEURforID(amount, id);
            functionsService.AddToAccount(this.User.FindFirstValue(ClaimTypes.Name), EUR, amount);
            historyService.AddHistoryEntry("9999999", this.User.FindFirstValue(ClaimTypes.NameIdentifier), DateTime.Now, EUR, amount);


            return RedirectToAction("Success", new { actionTpe = "Trade" });
        }




    }
}
