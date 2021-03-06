﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Homework.Models;
using Homework.Services;
using Homework.Repositories;
using Homework.Filter;

namespace Homework.Controllers
{
    public class MoneyController : Controller
    {
        //private MoneyDAO DAOData = new MoneyDAO();
        //private readonly MoneyServiceV1 _MoneyService;
        private readonly MoneyService _MoneyService;
        private readonly LogService _LogService;

        public MoneyController()
        {
            var UnitOfWork = new EFUnitOfWork();
            _MoneyService = new MoneyService(UnitOfWork);
            _LogService = new LogService(UnitOfWork);
        }

        public ActionResult Add()
        {
            //var model = new MoneyAddViewModels();
            //return View(model);
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key" , "value");

            if (ModelState.IsValid)
            {
                return View();                
            }
           
            return View();
        }

        [AuthorizePlus]
        [HttpPost]
        public ActionResult Add([Bind(Include = "Category,Amount,BillingDate,Memo")] MoneyAddViewModels MoneyAdd)
        {
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");

            if (ModelState.IsValid)
            {
                _MoneyService.Add(MoneyAdd);
                _LogService.Add(MoneyAdd.Category, MoneyAdd.Amount, "Add");
                _MoneyService.Save();

                //System.Threading.Thread.Sleep(3000);    //測試ajax
                //return View();
                return PartialView("List", _MoneyService.GetDataEF()); //加入ajax
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");

            var Year = Request.QueryString["yyyy"];
            var Month = Request.QueryString["mm"];
            if (Year == null || Month == null) 
            {
                // 全部資料
                //return View(_MoneyService.GetDataFake());        //使用假資料
                //return View(DAOData.GetData()); //使用DAO方式取得資料
                return View(_MoneyService.GetDataEF());          //使用EF code-first from db 取得資料
            }
            else
            {
                // 按年月查詢
                return View(_MoneyService.QueryYM(Year,Month));
            }
        }

        public ActionResult Detail(Guid? Id)
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook data = _MoneyService.GetSingle(Id.Value);
            return View(_MoneyService.Detail(data));
        }

    }
}