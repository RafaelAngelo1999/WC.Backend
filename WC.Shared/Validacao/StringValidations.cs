using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Shared.Validacao
{
    public class StringValidations : BaseValidations<string, StringValidations>
    {
        public StringValidations(string value) : base(value)
        {
        }

        public StringValidations IsNotNullOrWhiteSpace(string message = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                Error(message);

            return this;
        }

        public StringValidations HasLengthBetween(int min, int max, string message = null)
        {
            IsNotNull();

            if (value.Length < min || value.Length > max)
                Error(message);

            return this;
        }
    }
}