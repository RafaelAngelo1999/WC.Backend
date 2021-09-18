using System;

namespace WC.BackEnd.Model
{
    public class ErroModel
    {
        public string Mensagem { get; set; }
        public string Erro { get; set; }

        public ErroModel(string mensagem, Exception exception)
        {
            Mensagem = mensagem;
            Erro = exception.ToString();
        }

        public ErroModel(Exception exception)
        {
            Mensagem = exception.Message;
            Erro = exception.ToString();
        }
    }
}
