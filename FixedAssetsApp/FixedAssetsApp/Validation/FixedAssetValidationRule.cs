using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Validation
{
    public class FixedAssetValidationRule : ValidationRule
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

        public bool Empty
        {
            get { return _empty; }
            set { _empty = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            try
            {
                string inputString = (value ?? string.Empty).ToString().Trim();
                
                int x;
                bool converted = int.TryParse(inputString, out x);
                if (_empty && inputString.Length == 0) return result = new ValidationResult(true, null);
                if (!converted)
                {
                    return result = new ValidationResult(false, ErrorMessage);
                }
                
                if ((inputString.Length > _maximum) || (inputString.Length < _minimum)) result = new ValidationResult(false, ErrorMessage);

                if (inputString.Length == Maximum)
                {
                        using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                        {
                            client.Open();
                            FixedAsset dev = client.GetFixedAssetById(x);
                            client.Close();
                            if (dev == null)
                            {
                                result = new ValidationResult(false, "Podany środek trwały nie istnieje");
                            }
                        }
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
