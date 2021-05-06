using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDbContext db;
        private readonly IExchangeRateService exchangeRateService;

        public CurrencyService(ApplicationDbContext db, IExchangeRateService exchangeRateService)
        {
            this.db = db;
            this.exchangeRateService = exchangeRateService;
        }

        public void CreateCurrency(string Name)
        {
            var Currency = new Currency();
            Currency.Name = Name;
            db.Currencies.Add(Currency);
            db.SaveChanges();
        }

        public Currency ReadCurrency(int CurrencyId)
        {
            return db.Currencies.Where(x => x.CurrencyId.Equals(CurrencyId)).FirstOrDefault();
        }

        public void UpdateCurrency()
        {
            // to implement
        }

        public void DeleteCurrency(int CurrencyId)
        {
            var Currency = db.Currencies.Where(x => x.CurrencyId.Equals(CurrencyId)).FirstOrDefault();
            exchangeRateService.DeleteExchangeRate(CurrencyId);
            db.Currencies.Remove(Currency);
            db.SaveChanges();
        }

        public List<Currency> GetAllCurrencies()
        {
            return db.Currencies.ToList();
        }
    }
}
