using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace WC.Shared.Util
{
    public static class Filtros
    {
        public static string FiltrarDescricaoHTML (string descricaoHTML) 
        {
           return Regex.Replace(HttpUtility.HtmlDecode(descricaoHTML), @"\t|\n|\r", "");
        }

        public static float FiltrarPreco(string precoHTML)
        {
            return float.Parse(precoHTML.Remove(0, 2)); 
        }
        public static string TranformarUrlPesquisavel(string nomeProduto)
        {
            return HttpUtility.UrlEncode(Constantes.Variaveis.SITE_HAVAN + nomeProduto + "/");
        }
    }
}
