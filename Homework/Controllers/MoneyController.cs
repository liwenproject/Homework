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
        private MoneyEF EFData = new MoneyEF();
        private MoneyDAO DAOData = new MoneyDAO();
        private readonly MoneyService _MoneyService;

        public MoneyController()
        {
            _MoneyService = new MoneyService();
        }

        public ActionResult Add()
        {
            //var model = new MoneyAddViewModels();
            //return View(model);
            ViewData["CategoryList"] = MoneyModels.GetCategoryList();

            if (ModelState.IsValid)
            {
                return View();                
            }
           
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "Category,Amount,BillingDate,Memo")] MoneyAddViewModels MoneyAdd)
        {
            ViewData["CategoryList"] = MoneyModels.GetCategoryList();

            if (ModelState.IsValid)
            {
                _MoneyService.Add(MoneyAdd);
                _MoneyService.Save();
                return View();
            }

            return View();
        }


        public ActionResult List()
        {
            ViewData["CategoryList"] = MoneyModels.GetCategoryList();
            
            //return View(DataFake());        //使用假資料
            //return View(DAOData.GetData()); //使用DAO方式取得資料
            return View(EFData.GetData());          //使用EF code-first from db 取得資料
        }


        /// <summary>
        /// 假資料
        /// </summary>
        /// <returns></returns>
        private List<MoneyListViewModels> DataFake()
        {
            var model = new List<MoneyListViewModels>();
            model.Add(new MoneyListViewModels { Category = 0, Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") });
            model.Add(new MoneyListViewModels { Category = 1, Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") });
            model.Add(new MoneyListViewModels { Category = 0, Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") });

            return model;
        }


        /// <summary>
        /// 假資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MoneyListViewModels> DataFake2()
        {
            return new List<MoneyListViewModels>
            {
                new MoneyListViewModels { Category = 0, Amount = 300, BillingDate = Convert.ToDateTime("2016/01/01") },
                new MoneyListViewModels { Category = 1, Amount = 1600, BillingDate = Convert.ToDateTime("2016/01/02") },
                new MoneyListViewModels { Category = 0, Amount = 800, BillingDate = Convert.ToDateTime("2016/01/03") },
            };
        }

    }
}