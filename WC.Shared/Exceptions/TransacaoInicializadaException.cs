using System;

namespace WC.Shared.Exceptions
{
    public class TransacaoInicializadaException : AplicacaoException
    {
        public TransacaoInicializadaException() : base($"Transação precisa ser inicializada.") { }

        public TransacaoInicializadaException(Exception exception) : base($"Transação precisa ser inicializada.", exception) { }
    }
}
