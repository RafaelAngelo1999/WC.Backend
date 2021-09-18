using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Shared.Validacao
{
    public class BaseValidations<T, C> where C : BaseValidations<T, C>
    {
        protected readonly T value;

        public BaseValidations(T value)
        {
            this.value = value;
        }

        public C IsNotNull(string message = null)
        {
            if (value == null)
                Error(message);

            return (C)this;
        }

        public C IsNull(string message = null)
        {
            if (value != null)
                Error(message);

            return (C)this;
        }

        public C IsEqualTo(T otherValue, string message = null)
        {
            if (value == null || !value.Equals(otherValue))
                Error(message);

            return (C)this;
        }

        public C IsNotEqualTo(T otherValue, string message = null)
        {
            if (value == null || value.Equals(otherValue))
                Error(message);

            return (C)this;
        }

        public C AreEqualTo(T[] othersValues, string message = null)
        {
            if (value == null)
                Error(message);
            else
            {
                othersValues.ToList().ForEach(otherValue =>
                {
                    if (!value.Equals(otherValue))
                        Error(message);
                });
            }

            return (C)this;
        }

        public C AreNotEqualTo(T[] othersValues, string message = null)
        {
            if (value == null)
                Error(message);
            else
            {
                othersValues.ToList().ForEach(otherValue =>
                {
                    if (value.Equals(otherValue))
                        Error(message);
                });
            }

            return (C)this;
        }

        protected void Error(string message = null)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Validate.ThrowError(message);
            }
            else
            {
                Validate.ThrowError();
            }
        }
    }
}
