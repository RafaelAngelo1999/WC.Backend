using System;

namespace WC.Shared.Exceptions
{
    [Serializable]
    public class AplicacaoException : Exception
    {
        public AplicacaoException(string mensagem) : base(mensagem) { }
        public AplicacaoException(string mensagem, Exception exception) : base(mensagem, exception) { }
    }
}
