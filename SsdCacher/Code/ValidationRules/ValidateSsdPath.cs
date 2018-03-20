using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SsdCacher.Code.ValidationRules
{
    public class ValidateSsdPath : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = (string)value;

            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, "SSD Path must have a value.");
            }

            if (!Directory.Exists(stringValue))
            {
                return new ValidationResult(false, "SSD Path does not exist.");
            }

            return new ValidationResult(true, null);
        }
    }
}
