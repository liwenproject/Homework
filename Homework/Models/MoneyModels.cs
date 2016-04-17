using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework.Models
{
    public class MoneyModels
    {
        public static SelectList GetCategoryList()
        {
            var result = new SelectList(new[]
            {
                new { Value = "0", Text = "收入" },
                new { Value = "1", Text = "支出" },
            },
            "Value", "Text");            
            return result;
        }

    }
}