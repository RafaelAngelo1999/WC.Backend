using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WC.Infra.Data.Util
{
    public static class SqlUtil
    {
        public static string FormatarListaParametrosInteiros(List<int> valoresParametros)
        {
            return "(" + string.Join(",", valoresParametros) + ")";
        }

        public static string FormatarListaParametrosAlfanumericos(List<string> valoresParametros)
        {
            Regex alfanumericos = new Regex(@"^[a-zA-Z0-9]+$");
            StringBuilder parametros = new StringBuilder("(");
            bool primeiro = true;

            foreach (var valor in valoresParametros)
            {
                if (valor != null)
                {
                    // Validação para evitar SQL injection
                    if (!alfanumericos.IsMatch(valor))
                        throw new ArgumentException("O parâmetro " + valor + " possui caracteres não alfanuméricos.");

                    if (primeiro)
                    {
                        primeiro = false;
                    }
                    else
                    {
                        parametros.Append(",");
                    }

                    parametros.Append("'").Append(valor).Append("'");
                }
            }
            parametros.Append(")");

            return parametros.ToString();
        }

        public static void ValidarParametroAlfanumerico(string valor)
        {
            Regex alfanumericos = new Regex(@"^[a-zA-Z0-9]+$");

            if (!alfanumericos.IsMatch(valor))
                throw new ArgumentException("O parâmetro " + valor + " possui caracteres não alfanuméricos.");
        }

        public static string FormatarParametro(int? valor)
        {
            if (valor == null)
                return "NULL";

            return string.Format("{0}", valor);
        }

        public static string FormatarParametro<T>(T valor)
        {
            if (valor == null)
                return "NULL";

            return string.Format("\'{0}\'", valor);
        }

        public static string FormatarListaParametros<T>(IEnumerable<T> valor)
        {
            if (valor == null || !valor.Any())
                return "('')";

            valor.ToList().ForEach(v => FormatarParametro(v));

            return "('" + string.Join("', '", valor) + "')";
        }
    }
}
