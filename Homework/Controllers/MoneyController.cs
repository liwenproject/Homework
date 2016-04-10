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

        public ActionResult MoneyAdd()
        {
            //var model = new MoneyAddViewModels();
            //return View(model);

            ViewData["CategoryList"] = MoneyModels.GetCategoryList();
            return View();
        }

        public ActionResult MoneyList()
        {
            //先做假資料
            var model = new List<MoneyListViewModels>();          
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 100, BillingDate = Convert.ToDateTime("2016/04/01"), Memo = "買水果" });
            model.Add(new MoneyListViewModels { Category = "收入", Amount = 50000, BillingDate = Convert.ToDateTime("2016/04/05"), Memo = "薪資" });
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 1200, BillingDate = Convert.ToDateTime("2016/04/06"), Memo = "通訊費" });

            return View(model);
        }
    }
}