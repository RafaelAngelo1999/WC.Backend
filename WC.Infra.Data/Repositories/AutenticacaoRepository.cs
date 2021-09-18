
//using Dapper;
//using System.Collections;
//using System.Threading.Tasks;
//using WC.Domain.DTO;
//using WC.Infra.Data.Contexts.Interfaces;
//using WC.Infra.Data.Entities;
//using WC.Infra.Data.Interfaces;
//using WC.Infra.Data.Repositories.Base;

//namespace WC.Infra.Data.Repositories
//{
//    public class AutenticacaoRepository : RepositoryBase<Usuario>, IAutenticacaoRepository
//    {
//        protected AutenticacaoRepository(IDbContext contexto) : base(contexto) { }
//    }

//    public async Task<IEnumerable<Usuario>> AutenticarPorLoginSenha(string login, string senha)
//    {
//        private const string SQL_BUSCAR_DADOS_USUARIO = @"
//            SELECT ID AS Id, 
//                CPF AS Cpf,
//                NOME AS Nome,
//                EMAIL AS Email
//            FROM APOIO_BASICO_DADOS.USUARIO_CONVENIO 
//            WHERE CPF = @Cpf ";

//        public AutenticacaoRepository(IDbContext contexto) : base(contexto) { }

//        public UsuarioLogado AutenticarPorLoginSenha(string login, string senha)
//        {
//            var parametros = new DynamicParameters();
//            parametros.Add("@Login", login, System.Data.DbType.Int64);

//            return Obter(SQL_BUSCAR_DADOS_USUARIO, parametros);
//        }
//    }
//}
