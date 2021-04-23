using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly ApplicationDbContext db;

        public ExchangeRateService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void CreateExchangeRate(Currency Currency, float Rate)
        {
            var ExchangeRate = new ExchangeRate();
            ExchangeRate.Rate = Rate;
            ExchangeRate.Currency = Currency;           
            db.ExchangeRates.Add(ExchangeRate);
            db.SaveChanges();
        }

        public ExchangeRate ReadExchangeRate(int CurrencyId)
        {
            return db.ExchangeRates.Where(x => x.CurrencyId.Equals(CurrencyId)).FirstOrDefault();
        }

        public void UpdateExchangeRate(float rate, int id)
        {
            var eRate = ReadExchangeRate(id);
            eRate.Rate = rate;
            db.SaveChanges();
        }

        public void DeleteExchangeRate(int currencyId)
        {
            var ExchangeRate = db.ExchangeRates.Where(x => x.CurrencyId.Equals(currencyId)).FirstOrDefault();
            if(ExchangeRate != null)
            {
                db.ExchangeRates.Remove(ExchangeRate);
                db.SaveChanges();
            }
        }

    }
}
