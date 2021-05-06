using System.Collections.Generic;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public interface ICurrencyService
    {
        void CreateCurrency(string Name);
        void DeleteCurrency(int CurrencyId);
        Currency ReadCurrency(int CurrencyId);
        void UpdateCurrency();
        List<Currency> GetAllCurrencies();
    }
}