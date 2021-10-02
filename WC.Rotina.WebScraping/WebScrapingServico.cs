
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Shared.Configuracoes;

namespace WC.Rotina
{
    public class WebScrapingServico: IHostedService, IDisposable
    {
        private Timer _timer;
        private bool disposed = false;

        private IConfiguration Configuration { get; }
        private ILogger<WebScrapingServico> Logger { get; }
        private IServiceProvider Provider { get; }

        internal Aplicacao.ConfiguracaoServicoRotina Configuracao { get; private set; }
        internal IExecutarWebScrapingAppService ExecutarWebScrapingAppService { get; private set; }

        public WebScrapingServico(
            IConfiguration configuration,
            IServiceProvider provider,
            ILogger<WebScrapingServico> logger)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private async Task ExecutarAsync()
        {
            if (Configuracao.FimDeSemana || !(DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday))
            {
                await ExecutarServicoAsync().ConfigureAwait(false);
            }

            AlterarTempoExecucao();
        }

        public async Task ExecutarServicoAsync()
        {
            Logger.LogInformation("ROTINA PARA SCRAPING INICIADA ...");

            await ExecutarAppServices().ConfigureAwait(false);

            Logger.LogInformation("ROTINA PARA SCRAPING FINALIZADA");
        }

        private async Task ExecutarAppServices()
        {
            await ExecutarWebScrapingAsync().ConfigureAwait(false);
        }

        private async Task ExecutarWebScrapingAsync()
        {
            using (var scope = Provider.CreateScope())
            {
                ExecutarWebScrapingAppService = scope.ServiceProvider.GetRequiredService<IExecutarWebScrapingAppService>();

                if (ExecutarWebScrapingAppService == null)
                {
                    throw new ArgumentException($"Não foi possível recuperar '{nameof(ExecutarWebScrapingAppService)}'");
                }

                await ExecutarWebScrapingAppService.ExecutarWebScrapingAsync().ConfigureAwait(false);
            }
        }

        private void AlterarTempoExecucao()
        {
            if (Configuracao.Debug)
            {
                return;
            }

            var tempo = TempoCalculado();

            _timer.Change((int)tempo.TotalMilliseconds, Timeout.Infinite);
        }

        private TimeSpan TempoCalculado()
        {
            var (hoje, hora) = RecuperarProximaHora();

            return RecuperaTempoProximaExecucao(hoje, hora);
        }

        private TimeSpan RecuperaTempoProximaExecucao(bool hoje, int hora)
        {
            var tempo = new DateTime(DateTime.Now.AddDays(hoje ? 0 : 1).Year,
                DateTime.Now.AddDays(hoje ? 0 : 1).Month,
                DateTime.Now.AddDays(hoje ? 0 : 1).Day, hora, 0, 0) - DateTime.Now;

            Logger.LogWarning($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:s")} - " +
                $"Horário da próxima execução: {DateTime.Now.Add(tempo).ToString("dd/MM/yyyy HH:mm:ss")}");

            Logger.LogInformation($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:s")} - " +
                $"Horário da próxima execução: {DateTime.Now.Add(tempo).ToString("dd/MM/yyyy HH:mm:ss")}");

            return tempo;
        }

        private (bool hoje, int hora) RecuperarProximaHora()
        {
            if (Configuracao.Horarios.Any(h => h > DateTime.Now.Hour))
            {
                return (true, Configuracao.Horarios.FirstOrDefault(w => w > DateTime.Now.Hour));
            }

            return (false, Configuracao.Horarios.First());
        }

        private TSection ObterConfiguracao<TSection>(string chave)
        {
            return Configuration.GetSection($"AppConfiguration:{chave}").Get<TSection>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"[{nameof(WebScrapingServico)}] - Windows Service iniciado.");

                Configuracao = ObterConfiguracao<Aplicacao.ConfiguracaoServicoRotina>("ServicoRotina");

                if (Configuracao == null) throw new ArgumentException("ServicoRotina");

                if (Configuracao.Debug)
                {
                    await ExecutarAsync().ConfigureAwait(false);
                }
                else
                {
                    var tempo = TempoCalculado();

                    _timer = new Timer(async (e) => await ExecutarAsync().ConfigureAwait(false), null, Configuracao.AoIniciar ? 0 : (int)tempo.TotalMilliseconds, Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ocorreu um erro na execução. \nMensagem: {Message} \nStackTrace: {StackTrace}", ex.Message, ex.StackTrace);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (Configuracao.Debug)
            {
                Thread.Sleep(1000);
            }
            else
            {
                _timer?.Change(Timeout.Infinite, 0);
            }

            Logger.LogInformation($"[{nameof(WebScrapingServico)}] - Windows Service finalizado.");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _timer?.Dispose();
                }

                disposed = true;
            }
        }

    }
}
