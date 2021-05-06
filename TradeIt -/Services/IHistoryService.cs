using System;
using System.Collections.Generic;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public interface IHistoryService
    {
        void AddHistoryEntry(string senderId, string receiverId, DateTime date, string currencyType, float amount);
        ICollection<History> GetHistories(string userId);
    }
}