﻿using System;
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
            var list = new SelectList(new[]
            {
                new { ID = "Income", Name = "收入" },
                new { ID = "Expense", Name = "支出" },
            },
            "ID", "Name", 1);
            return list;
        }

    }
}