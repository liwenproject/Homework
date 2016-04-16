using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework.Models;

namespace Homework.Controllers
{
    public class MoneyController : Controller
    {
        private MoneyEFModels db = new MoneyEFModels();

        public ActionResult Add()
        {
            //var model = new MoneyAddViewModels();
            //return View(model);

            ViewData["CategoryList"] = MoneyModels.GetCategoryList();
            return View();
        }

        public ActionResult List()
        {
            //return View(FakeData());
            return View(FEData());
        }

        /// <summary>
        /// 資料來源：用EF (code-first from db)產生
        /// </summary>
        /// <returns></returns>
        private List<MoneyListViewModels> FEData()
        {
            int PageRows = 1000;
            var model = new List<MoneyListViewModels>();
            foreach(var item in db.AccountBook.Take(PageRows).ToList())
            {
                model.Add(new MoneyListViewModels {
                    Category = item.Categoryyy.ToString(),
                    Amount = item.Amounttt,
                    BillingDate = item.Dateee
                });
            }
            return model;
        }

        /// <summary>
        /// 假資料
        /// </summary>
        /// <returns></returns>
        private List<MoneyListViewModels> FakeData()
        {
            var model = new List<MoneyListViewModels>();
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") });
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") });
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") });

            return model;
        }

    }
}