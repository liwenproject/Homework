using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult EarlierSameToday(DateTime BillingDate)
        {
            //bool result = false;
            //if (DateTime.Compare(input, DateTime.Today) <= 0)  result = true;

            bool result = DateTime.Compare(BillingDate, DateTime.Today) <= 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}