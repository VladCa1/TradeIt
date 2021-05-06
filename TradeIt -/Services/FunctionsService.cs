using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;

namespace TradeIt__.Services
{
    public class FunctionsService : IFunctionsService
    {

        private readonly ApplicationDbContext db;
        private readonly IAccountService accountService;
        private readonly IExchangeRateService exchangeRateService;

        public FunctionsService(ApplicationDbContext db,
            IAccountService accountService,
            IExchangeRateService exchangeRateService)
        {
            this.db = db;
            this.accountService = accountService;
            this.exchangeRateService = exchangeRateService;
        }


        public void AddToAccount(string username, string currencyType, float amount)
        {
            var currency1 = db.Currencies.FirstOrDefault(x => x.Name.Equals(currencyType));
            var balance = db.Balances.Where(x => 
                x.Portofolio.UserId.Equals(accountService.GetUserIdForUsername(username)) &&
                x.CurrencyId.Equals(currency1.CurrencyId))
                    .FirstOrDefault();
            if(balance == null)
            {
                balance = new Models.Balance();
                balance.Amount = amount;
                balance.Currency = currency1;
                balance.Portofolio = db.Portoflios.FirstOrDefault(x => x.UserId.Equals(accountService.GetUserIdForUsername(username)));
                db.Portoflios.FirstOrDefault(x => x.UserId.Equals(accountService.GetUserIdForUsername(username))).Balances.Add(balance);
            }
            else
            {
                balance.Amount += amount;
            }

            db.SaveChanges();
        }

        public void DedudctFromAccount(string username, string currencyType, float amount)
        {
            var currency1 = db.Currencies.FirstOrDefault(x => x.Name.Equals(currencyType)).CurrencyId;
            var balance = db.Balances.Where(x => 
                x.Portofolio.UserId.Equals(accountService.GetUserIdForUsername(username)) && 
                x.CurrencyId.Equals(currency1))
                    .FirstOrDefault();
            balance.Amount -= amount;
            db.SaveChanges();
        }

        public float ConvertToEURforID(float amount, int id)
        {
            var rate = exchangeRateService.ReadExchangeRate(id).Rate;
            return amount * rate;
        }


    }
}
