using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;
using TradeIt__.Models;

namespace TradeIt__.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext db;

        public HistoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddHistoryEntry(string senderId, string receiverId, DateTime date, string currencyType, float amount)
        {
            var currency = db.Currencies.FirstOrDefault(x => x.Name.Equals(currencyType));
            var entry = new History(amount, date, senderId, receiverId);
            entry.CurrencyName = currencyType;
            entry.Currency = currency;
            entry.ReceiverUserName = db.Users.FirstOrDefault(x => x.Id.Equals(receiverId)).UserName;
            entry.SenderUserName = db.Users.FirstOrDefault(x => x.Id.Equals(senderId)).UserName;
            db.TransactionsHistory.Add(entry);
            db.SaveChanges();
        }

        public ICollection<History> GetHistories(string userId)
        {
            return db.TransactionsHistory.Where(x => x.ReceiverId.Equals(userId) || x.SenderId.Equals(userId)).ToList();
        }
    }
}
