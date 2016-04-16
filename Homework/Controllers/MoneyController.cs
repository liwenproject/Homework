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

        public ActionResult Add()
        {
            //var model = new MoneyAddViewModels();
            //return View(model);

            ViewData["CategoryList"] = MoneyModels.GetCategoryList();
            return View();
        }

        public ActionResult List()
        {
            //先做假資料
            var model = new List<MoneyListViewModels>();          
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") });
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") });
            model.Add(new MoneyListViewModels { Category = "支出", Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") });

            return View(model);
        }
    }
}