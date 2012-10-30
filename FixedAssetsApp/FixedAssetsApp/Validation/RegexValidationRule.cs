using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FixedAssetsApp.Validation
{
    public class RegexValidationRule : ValidationRule
    {
        private string _errorMessage;
        private bool _empty;
        private string _type;  
        private string patternStrict;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public bool Empty
        {
            get { return _empty; }
            set { _empty = value; }
        }

        public string TypeRegax
        {
            get { return _type; }
            set { _type = value; }
        }


        private string email = @"^(([^<>()[\]\\.,;:\s@\""]+"
                       + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                       + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                       + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                       + @"[a-zA-Z]{2,}))$";

        private string ip = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\."
                   + @"([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);


            switch (TypeRegax)
            {
                case "email":
                    patternStrict = email;
                    break;
                case "ipaddress":
                    patternStrict = ip;
                    break;
            }

                string inputString = (value ?? string.Empty).ToString().Trim();

                if (_empty && inputString.Length == 0) return result = new ValidationResult(true, null);

                Regex reStrict = new Regex(patternStrict);
                bool isStrictMatch = reStrict.IsMatch(inputString);
                if (!isStrictMatch)
                {
                    result = new ValidationResult(false, this.ErrorMessage);
                }

                return result;
        }
    }
}
