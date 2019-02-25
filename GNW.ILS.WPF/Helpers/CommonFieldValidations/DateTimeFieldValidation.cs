using System;
using System.Globalization;
using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers.CommonFieldValidations
{
  public  class DateTimeFieldValidation : ValidationRule
    {
      public string ErrorMsg { get; set; }

      public DateTimeFieldValidation()
      {
          ErrorMsg = "Blank or Invalid Date Format";
      }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string dateTime = value.ToString();

            try
            {
                Convert.ToDateTime(dateTime);
                return new ValidationResult(true, null);
            }
            catch (Exception ex)
            { return new ValidationResult(false, ErrorMsg); }
        }
    }
}
