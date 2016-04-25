using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.Mvc;

namespace Homework.App_Code
{
    public class DictInfo
    {
        public string Desc { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
    }

    public class MyDictionary
    {
        public static Dictionary<int, string> Category = new Dictionary<int, string>()
        {
            {0, "收入" },
            {1, "支出" }
        };
        public static Dictionary<int, DictInfo> CategoryInfo = new Dictionary<int, DictInfo>()
        {
            {0, new DictInfo { Desc=Category[0] , ForeColor=Color.Blue, BackColor=Color.Transparent} },
            {1, new DictInfo { Desc=Category[1] , ForeColor=Color.Red, BackColor=Color.Transparent} }
        };
    }
}