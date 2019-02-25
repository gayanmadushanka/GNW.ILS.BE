using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GNW.ILS.WPF.Helpers.CommonFieldValidations
{
    public class EmailFieldValidation : ValidationRule
    {
        public string ErrorMsg { get; set; }

        public EmailFieldValidation()
        {
            ErrorMsg = "Invalid Email Address";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            const string matchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                             + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                             + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            string email = value.ToString();
            if (!string.IsNullOrEmpty(email))
            {
                Regex regex = new Regex(matchEmailPattern);
                Match match = regex.Match(email);
                if (!match.Success)
                {
                    return new ValidationResult(false, ErrorMsg);
                }
            }
            return new ValidationResult(true, null);
        }
    }

}
