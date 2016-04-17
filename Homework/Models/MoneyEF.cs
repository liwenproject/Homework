namespace Homework.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    public partial class MoneyEF : DbContext
    {
        public MoneyEF()
            : base("name=MoneyEF")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        /// <summary>
        /// 資料來源：用EF (code-first from db)產生
        /// </summary>
        /// <returns></returns>
        public List<MoneyListViewModels> GetData()
        {
            int PageRows = 1000;
            var result = new List<MoneyListViewModels>();
            foreach (var item in AccountBook.Take(PageRows).ToList())
            {
                result.Add(new MoneyListViewModels
                {
                    Category = item.Categoryyy.ToString(),
                    Amount = item.Amounttt,
                    BillingDate = item.Dateee
                });
            }
            return result;
        }

    }
}
