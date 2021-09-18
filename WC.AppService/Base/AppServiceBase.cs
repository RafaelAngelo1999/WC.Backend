using WC.Infra.Data.Contexts.Interfaces;
using System;

namespace WC.AppService.Base
{
    public abstract class AppServiceBase : IDisposable
    {
        protected readonly IDbContext Contexto;

        protected AppServiceBase(IDbContext contexto)
        {
            Contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Contexto != null)
                Contexto.Dispose();
        }

        public void InicializarTransacao()
        {
            Contexto.InicializarTransacao();
        }

        public void ConfirmarTransacao()
        {
            Contexto.ConfirmarTransacao();
        }

        public void DesfazerTransacao()
        {
            Contexto.DesfazerTransacao();
        }

        protected void ExecutarEmTransacao(Action action)
        {
            try
            {
                InicializarTransacao();
                action.Invoke();
                ConfirmarTransacao();
            }
            catch
            {
                DesfazerTransacao();
                throw;
            }
        }

        protected T ExecutarEmTransacao<T>(Func<T> func)
        {
            try
            {
                InicializarTransacao();
                T resultado = func.Invoke();
                ConfirmarTransacao();

                return resultado;
            }
            catch
            {
                DesfazerTransacao();
                throw;
            }
        }
    }
}
