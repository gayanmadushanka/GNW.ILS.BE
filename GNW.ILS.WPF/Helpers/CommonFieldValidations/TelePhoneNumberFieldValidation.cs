using System;
using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers.CommonFieldValidations
{
    class TelePhoneNumberFieldValidation: ValidationRule
    {
        public string ErrorMsg { get; set; }

        public string ErrorField { get; set; }

        public TelePhoneNumberFieldValidation()
        {
            ErrorMsg = "should have 10 dights";
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {            
            string telephoneNo = value.ToString().Trim();
            if (!String.IsNullOrEmpty(telephoneNo))
            {
                if(telephoneNo.Length!=10)
                {
                    return new ValidationResult(false, ErrorField + " " + ErrorMsg);
                }
                else
                {
                    foreach(char eachChar in telephoneNo.ToCharArray())
                    {
                        if(!Char.IsDigit(eachChar))
                        {
                            return new ValidationResult(false, ErrorField + " " + ErrorMsg);
                        }
                    }
                }
            }          
            return new ValidationResult(true, null);
        }
    }

}
