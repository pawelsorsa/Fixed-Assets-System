using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace FixedAssetsApp.Validation
{
    public class IntegerRangeValidationRule : ValidationRule
    {
        private int _minimum;
        private int _maximum;
        private bool _empty; 
        private string _errorMessage;

        public int Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        public int Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }

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

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            try
            {
                string inputString = (value ?? string.Empty).ToString();

                int x;
                bool converted = int.TryParse(inputString, out x);
                if (_empty && inputString.Length == 0) return result = new ValidationResult(true, null);
                if (!converted || (x > Maximum) || (x < Minimum))
                {
                    result = new ValidationResult(false, ErrorMessage);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
        }
    }
}
