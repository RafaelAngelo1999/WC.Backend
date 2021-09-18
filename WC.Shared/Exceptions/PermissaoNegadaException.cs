using System;

namespace WC.Shared.Exceptions
{
    [Serializable]
    public class PermissaoNegadaException : AplicacaoException
    {
        public PermissaoNegadaException(string mensagem) : base(mensagem) { }
    }
}
