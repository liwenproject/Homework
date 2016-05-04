using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework.Filter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                    inherit: true);

            //有設定 AllowAnonymous 就跳過
            if (skipAuthorization)
            {
                return;
            }

            //驗證是否是授權的連線。
            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                //未登入，StatusCode=401
                filterContext.Result = new HttpUnauthorizedResult();
            }
            else
            {
                //不在Users內，導向首頁
                if (AuthorizeCore(filterContext.HttpContext) == false)
                {
                    var urlHelper = new UrlHelper(filterContext.RequestContext);
                    var redirectUrl = urlHelper.Action("Index", "Home", new { area = "" });
                    filterContext.Result = new RedirectResult(redirectUrl);
                }
            }

            //驗證是否是授權的連線，並且是 AJAX 呼叫。
            if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                ContentResult cr = new ContentResult();
                cr.Content = "<p style=\"color:Red;font-weight:bold;\">您尚未登入無法觀看!! 請先登入後再嘗試。</p>";
                filterContext.Result = cr;
            }

        }
    }

}