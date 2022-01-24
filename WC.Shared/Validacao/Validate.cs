using WC.Shared.Exceptions;

namespace WC.Shared.Validacao
{
    public static class Validate
    {
        public static StringValidations That(string value)
        {
            return new StringValidations(value);
        }

        public static void ThrowError()
        {
            throw new ParametroInvalidoException();
        }

        public static void ThrowError(string message)
        {
            throw new ParametroInvalidoException(message);
        }
    }
}
