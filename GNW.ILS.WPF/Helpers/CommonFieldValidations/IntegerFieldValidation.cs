using System;
using System.Globalization;
using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers.CommonFieldValidations
{
    public class IntegerFieldValidation : ValidationRule
    {
        public string ErrorMsg { get; set; }

        public string ErrorField { get; set; }

        public IntegerFieldValidation()
        {
            ErrorMsg = "should be an Integer!";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intNumber;

            if (Int32.TryParse(value.ToString(), out intNumber))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, ErrorField + " " + ErrorMsg);
        }
    }

}
