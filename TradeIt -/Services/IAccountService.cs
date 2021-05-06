using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public interface IAccountService
    {
        Balance GetAccountBalance(string userId, int currencyId);
        public ICollection<Models.Balance> GetAccountBalances(string userId);
        string GetUserIdForUsername(string username);
        bool IsValidBalance(string username, string currency, float amount);
        bool IsValidUsername(string username);
    }
}
