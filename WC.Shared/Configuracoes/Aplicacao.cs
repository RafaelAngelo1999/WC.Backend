using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Shared.Configuracoes
{
    public class Aplicacao
    {
        public string ConexaoCache { get; set; }
        public string JwtSegredo { get; set; }
        public ConfiguracoesServico ServicoAutenticacao { get; set; }
        public ConfiguracoesServico ServicoExames { get; set; }
        public ConfiguracoesServico ServicoSecurity { get; set; }
        public ConfiguracoesServico ServicoIntegracaoConvenio { get; set; }
        public ConfiguracoesServicoHttpBasic ServicoAtualizarTabelaPromo { get; set; }
        public ToggleFeature ToggleFeatureParametros { get; set; }
        public ConfiguracoesEmail Email { get; set; }

        public class ConfiguracoesServicosApi
        {
            public string Id { get; set; }
            public string Versao { get; set; }
            public string Rota { get; set; }
            public List<ConfiguracoesServicoApiParametros> Parametros { get; set; }
        }

        public class ConfiguracoesServico
        {
            public string Url { get; set; }
            public string Origem { get; set; }
            public List<ConfiguracoesServicosApi> Servicos { get; set; }
        }

        public class ConfiguracoesServicoApiParametros
        {
            public string Nome { get; set; }
            public string Tipo { get; set; }
        }

        public class ConfiguracoesServicoHttpBasic : ConfiguracoesServico
        {
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }

        public class ConfiguracoesLogSlack
        {
            public bool Ativo { get; set; }
            public string SlackUrlWebHook { get; set; }
            public string SlackChannelWebHook { get; set; }
        }

        public class ToggleFeature
        {
            public bool Habilitado { get; set; }
        }

        public class ConfiguracoesEmail
        {
            public string RemetenteEmail { get; set; }
            public string ServidorSmtp { get; set; }
            public int PortaServidorSmtp { get; set; }
            public string PrefixoAmbiente { get; set; }
            public AutenticacaoSmtpEmail AutenticacaoSmtp { get; set; }
            public bool HabilitarSsl { get; set; }
        }

        public class AutenticacaoSmtpEmail
        {
            public bool Autenticar { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }

        public class ConfiguracaoServicoRotina
        {
            public int[] Horarios { get; set; }
            public bool AoIniciar { get; set; }
            public bool FimDeSemana { get; set; }
            public bool Debug { get; set; }
        }
    }
}
