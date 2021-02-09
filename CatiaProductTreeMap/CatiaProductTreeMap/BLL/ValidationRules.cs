using CatiaProductTreeMap.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CatiaProductTreeMap.BLL
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // MainWindow为当前窗口类
            MainWindow mainwin = Application.Current.MainWindow as MainWindow;
            if (Regex.IsMatch(value.ToString(), @"^[-]?\d+[.]?\d*$") || value.ToString() == "")
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "");
            }
        }
    }
}
