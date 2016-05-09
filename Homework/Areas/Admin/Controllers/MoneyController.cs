using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework.Models;
using Homework.Repositories;
using Homework.Services;
using System.Net;
using Homework.Filter;

namespace Homework.Areas.Admin.Controllers
{
    //[Authorize(Users = "admin@test.test")]
    [AuthorizePlus(Users = "admin@test.test")]
    public class MoneyController : Controller
    {
        private readonly MoneyService _MoneyService;
        private readonly LogService _LogService;

        public MoneyController()
        {
            var UnitOfWork = new EFUnitOfWork();
            _MoneyService = new MoneyService(UnitOfWork);
            _LogService = new LogService(UnitOfWork);
        }

        // GET: Admin/Money
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");

            var Year = Request.QueryString["yyyy"];
            var Month = Request.QueryString["mm"];
            if (Year == null || Month == null)
            {
                // 全部資料
                return View(_MoneyService.GetDataEF());
            }
            else
            {
                // 按年月查詢
                return View(_MoneyService.QueryYM(Year, Month));
            }
        }

        public ActionResult Detail(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook data = _MoneyService.GetSingle(Id.Value);
            return View(_MoneyService.Detail(data));
        }

        [Authorize]
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

            return RedirectToAction("List");
        }

        [Authorize]
        public ActionResult Edit(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountBook data = _MoneyService.GetSingle(Id.Value);

            ViewData["CategoryList"] = new SelectList(DataDict.Category, "key", "value");
            return View(_MoneyService.Detail(data));
        }

        [Authorize]
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
                return RedirectToAction("List");
            }
            return View();
        }

    }
}