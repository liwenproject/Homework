﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework.Models
{
    public class MoneyListViewModels
    {
        [Display(Name = "序號")]
        public Guid Id { get; set; }
        [Display(Name = "類別")]
        public int Category { get; set; }
        [Display(Name = "日期")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BillingDate { get; set; }
        [Display(Name = "金額")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:#,##0}")]
        [UIHint("Amount")]
        public Int32 Amount { get; set; }
    }
}