using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;

namespace TradeIt__.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext db;
        private readonly ICurrencyService currencyService;

        public AccountService(ApplicationDbContext db,
            ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
            this.db = db;
        }

        public string GetUserIdForUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName.Equals(username)).Id;
        }


        public ICollection<Models.Balance> GetAccountBalances(string userId)
        {
            var portofolio = db.Portoflios.FirstOrDefault(x => x.UserId.Equals(userId));
            var balances = db.Balances.Where(x => x.PortofolioId.Equals(portofolio.PortofolioId)).ToList();
            return balances;
        }

        public Models.Balance GetAccountBalance(string userId, int currencyId)
        {
            var portofolio = db.Portoflios.FirstOrDefault(x => x.UserId.Equals(userId));
            var balance = db.Balances.Where(x => x.PortofolioId.Equals(portofolio.PortofolioId) && x.CurrencyId.Equals(currencyId)).FirstOrDefault();
            return balance;
        }

        public bool IsValidUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName.Equals(username)) != null;
        }

        public bool IsValidBalance(string username, string currency, float amount)
        {
            var currency1 = db.Currencies.FirstOrDefault(x => x.Name.Equals(currency)).CurrencyId;
            var userId = db.Users.FirstOrDefault(x => x.UserName == username).Id;
            var portofolio = db.Portoflios.FirstOrDefault(x => x.UserId == userId);
            return db.Balances.FirstOrDefault(x => x.CurrencyId.Equals(currency1) && x.PortofolioId.Equals(portofolio.PortofolioId)).Amount >= amount ? true : false;
        }


    }
}
