using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace FixedAssetsApp.Validation
{
    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;
        public bool _empty;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
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
                if (_empty && inputString.Length == 0) return result = new ValidationResult(true, null);
                if (inputString.Length < this.MinimumLength ||
                       (this.MaximumLength > 0 &&
                        inputString.Length > this.MaximumLength))
                {
                    result = new ValidationResult(false, this.ErrorMessage);
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
