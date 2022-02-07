using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Settings
{
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute(int years1, int years2)
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(years1).ToShortDateString(),
                  DateTime.Now.AddYears(years2).ToShortDateString())
        { }
    }
}
