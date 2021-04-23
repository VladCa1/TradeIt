using TradeIt__.Models;

namespace TradeIt__.Services
{
    public interface IExchangeRateService
    {
        void CreateExchangeRate(Currency Currency, float Rate);
        void DeleteExchangeRate(int currencyId);
        ExchangeRate ReadExchangeRate(int ExchangeRateId);
        void UpdateExchangeRate(float rate, int id);
    }
}