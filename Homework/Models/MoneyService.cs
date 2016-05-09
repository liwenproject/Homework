using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Homework.Models;
using Homework.Repositories;
using System.Linq.Expressions;

namespace Homework.Services
{
    public class MoneyService
    {
       // MoneyEF _db;
        IRepository<AccountBook> _AccountBookRep;
        public MoneyService(IUnitOfWork UnitOfWork)
        {
           // _db = new MoneyEF();
            _AccountBookRep = new Repository<AccountBook>(UnitOfWork);
        }

        /// <summary>
        /// 資料來源：用EF (code-first from db)產生
        /// </summary>
        /// <returns></returns>
        public List<MoneyListViewModels> GetDataEF()
        {
            var result = new List<MoneyListViewModels>();
            //foreach (var item in _db.AccountBook.Take(PageRows).OrderByDescending(c => c.Dateee).ToList())
            foreach (var item in _AccountBookRep.LookupAll().OrderByDescending(c => c.Dateee).ToList())
            {
                result.Add(new MoneyListViewModels
                {
                    Id = item.Id,
                    Category = item.Categoryyy,
                    Amount = item.Amounttt,
                    BillingDate = item.Dateee
                });
            }
            return result;
        }

        /// <summary>
        /// 資料來源：假資料
        /// </summary>
        /// <returns></returns>
        public List<MoneyListViewModels> GetDataFake()
        {
            var model = new List<MoneyListViewModels>();
            model.Add(new MoneyListViewModels { Category = 0, Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") });
            model.Add(new MoneyListViewModels { Category = 1, Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") });
            model.Add(new MoneyListViewModels { Category = 0, Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") });

            return model;
        }
        /// <summary>
        /// 資料來源：假資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MoneyListViewModels> GetDataFake2()
        {
            return new List<MoneyListViewModels>
            {
                new MoneyListViewModels { Category = 0, Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") },
                new MoneyListViewModels { Category = 1, Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") },
                new MoneyListViewModels { Category = 0, Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") },
            };
        }

        /// <summary>
        /// 按年月查詢
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public List<MoneyListViewModels> QueryYM(string Year, string Month)
        {
            var empty = new List<MoneyListViewModels>();
            int iYear, iMonth;
            if (!int.TryParse(Year.Trim(), out iYear) || !int.TryParse(Month.Trim(), out iMonth))
            {
                return empty;  //需補上錯誤處理
            }
            if (iYear < 1991 || iYear > DateTime.Today.Year || iMonth < 1 || iMonth > 12)
            {
                return empty;  //需補上錯誤處理
            }

            DateTime BeginDate = new DateTime(iYear, iMonth, 01, 00, 00, 00);
            DateTime EndDate = BeginDate.AddMonths(1);
            //return Query(c => c.Amounttt > 70000);
            return Query(c => c.Dateee >= BeginDate && c.Dateee < EndDate);
        }

        /// <summary>
        /// 查詢-EF-DB
        /// </summary>
        /// <param name="money"></param>
        public List<MoneyListViewModels> Query(Expression<Func<AccountBook, bool>> filter)
        {
            var result = new List<MoneyListViewModels>();
            foreach (var item in _AccountBookRep.Query(filter).OrderByDescending(c => c.Dateee).ToList())
            {
                result.Add(new MoneyListViewModels
                {
                    Id = item.Id,
                    Category = item.Categoryyy,
                    Amount = item.Amounttt,
                    BillingDate = item.Dateee
                });
            }
            return result;
        }


        /// <summary>
        /// 明細
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public MoneyAddViewModels Detail(AccountBook data)
        {
            var result = new MoneyAddViewModels()
            {
                Id = data.Id,
                Category = data.Categoryyy,
                Amount = data.Amounttt,
                BillingDate = data.Dateee,
                Memo = data.Remarkkk
            };
            return result;
        }

        /// <summary>
        /// 新增-傳入 ViewModel 資料
        /// </summary>
        /// <param name="MoneyAdd"></param>
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

        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="MoneyAdd"></param>
        /// <param name="olddata"></param>
        public void Edit(MoneyAddViewModels MoneyAdd, AccountBook olddata)
        {
            var newdata = new AccountBook()
            {
                Id = MoneyAdd.Id,
                Categoryyy = MoneyAdd.Category,
                Amounttt = MoneyAdd.Amount,
                Dateee = MoneyAdd.BillingDate,
                Remarkkk = MoneyAdd.Memo
            };
            Edit(newdata, olddata);
        }

        /// <summary>
        /// 新增-EF-DB
        /// </summary>
        /// <param name="money"></param>
        public void Add(AccountBook data)
        {
            data.Id = Guid.NewGuid();
            //_db.AccountBook.Add(data);
            _AccountBookRep.Create(data);
        }

        /// <summary>
        /// 取得一筆-EF-DB
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AccountBook GetSingle(Guid Id)
        {
            //return _db.AccountBook.Find(Id);
            return _AccountBookRep.GetSingle(c => c.Id == Id);
        }

        /// <summary>
        /// 刪除-EF-DB
        /// </summary>
        /// <param name="data"></param>
        public void Delete(AccountBook data)
        {
            //_db.AccountBook.Remove(data);
            _AccountBookRep.Remove(data);
        }

        /// <summary>
        /// 更新-EF-DB
        /// </summary>
        /// <param name="newdata"></param>
        /// <param name="olddata"></param>
        public void Edit(AccountBook newdata, AccountBook olddata)
        {
            olddata.Categoryyy = newdata.Categoryyy;
            olddata.Amounttt = newdata.Amounttt;
            olddata.Dateee = newdata.Dateee;
            olddata.Remarkkk = newdata.Remarkkk;
        }

        /// <summary>
        /// 儲存-EF-DB
        /// </summary>
        public void Save()
        {
            //_db.SaveChanges();
            _AccountBookRep.Commit();
        }


    }

}