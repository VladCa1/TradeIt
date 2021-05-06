namespace TradeIt__.Services
{
    public interface IFunctionsService
    {
        void AddToAccount(string username, string currencyType, float amount);
        float ConvertToEURforID(float amount, int id);
        void DedudctFromAccount(string username, string currencyType, float amount);
    }
}