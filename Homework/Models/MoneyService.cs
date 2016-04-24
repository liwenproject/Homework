using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Homework.Models
{
    public class MoneyService
    {
        MoneyEF _db;
        public MoneyService()
        {
            _db = new MoneyEF();
        }

        public void Add(MoneyAddViewModels MoneyAdd)
        {
            var result = new AccountBook()
            {
                Categoryyy = MoneyAdd.Category,
                Amounttt = MoneyAdd.Amount,
                Dateee = MoneyAdd.BillingDate,
                Remarkkk = MoneyAdd.Memo
            };
            Add(result);
        }

        public void Add(AccountBook money)
        {
            money.Id = Guid.NewGuid();
            _db.AccountBook.Add(money);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }

}