using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Homework.Models;
using Homework.Services;
using Homework.Repositories;

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

        [HttpPost]
        public ActionResult Add([Bind(Include = "Category,Amount,BillingDate,Memo")] MoneyAddViewModels MoneyAdd)
        {
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");

            if (ModelState.IsValid)
            {
                _MoneyService.Add(MoneyAdd);
                _LogService.Add(MoneyAdd.Category, MoneyAdd.Amount, "Add");
                _MoneyService.Save();
                return View();
                //return RedirectToAction("Add");
            }

            return View();
        }


        public ActionResult List()
        {
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");

            //return View(_MoneyService.GetDataFake());        //使用假資料
            //return View(DAOData.GetData()); //使用DAO方式取得資料
            return View(_MoneyService.GetDataEF());          //使用EF code-first from db 取得資料
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

        public ActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook data = _MoneyService.GetSingle(Id.Value);
            if (data == null)
            {
                return HttpNotFound();
            }

            _MoneyService.Delete(data);
            _LogService.Add(data.Categoryyy, data.Amounttt, "Delete");
            _MoneyService.Save();

            return RedirectToAction("Add");
        }

        public ActionResult Edit(Guid? Id)
        {
            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook data = _MoneyService.GetSingle(Id.Value);

            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");
            return View(_MoneyService.Detail(data));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Category,Amount,BillingDate,Memo")] MoneyAddViewModels MoneyAdd)
        {
            AccountBook olddata = _MoneyService.GetSingle(MoneyAdd.Id);
            if (olddata != null && ModelState.IsValid)
            {
                _MoneyService.Edit(MoneyAdd, olddata);
                _LogService.Add(olddata.Categoryyy, olddata.Amounttt, "EditBefore");
                _LogService.Add(MoneyAdd.Category, MoneyAdd.Amount, "EditAfter");
                _MoneyService.Save();
                return RedirectToAction("Add");
            }
            return View();
        }

    }
}