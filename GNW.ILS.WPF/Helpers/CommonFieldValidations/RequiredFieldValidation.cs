using System;
using System.Globalization;
using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers.CommonFieldValidations
{
    public class RequiredFieldValidation : ValidationRule
    {
        public string ErrorMsg { get; set; }

        public string ErrorField { get; set; }

        public RequiredFieldValidation()
        {
            ErrorMsg = "cannot leave blank! \n";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value.ToString();
            if (string.IsNullOrEmpty(text))
            {
                return new ValidationResult(false, ErrorField + " " + ErrorMsg);
            }
            return new ValidationResult(true, null);
        }
    }
}
