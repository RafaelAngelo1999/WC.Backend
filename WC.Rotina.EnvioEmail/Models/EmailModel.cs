using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Rotina.EnvioEmail.Models
{
    public static class EmailModel
    {
        public const string TEMPLATE_EMAIL_FEEDBACK = @"
                <html>
                  <head>
                    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                    <style>
                        body {
                            font-family: Tahoma, Arial, sans-serif;
                            font-size: 14px;
                        }
                        table {
                            border-collapse: collapse;
                            width: 100%;
                        }
                        td,
                        th {
                            border: 1px solid #dddddd;
                            border-left: none;
                            border-right: none;
                            text-align: left;
                            padding: 8px;
                            color: #61688B;
                            font-size: 14px;
                        }
                        th {
                            vertical-align: bottom;
                        }
                        .coluna-numero {
                            text-align: right;
                            width: 180px;
                        }
                    </style>
                  </head>
                  <body>
                    <p>
                       Olá, ##alcada##
                    </p>
                    <p>
                        A cotação ""##nomeDaCotacao##"" para o cliente ""##codigoLaboratorio## - ##nomeLaboratorio## "" de ##nomeresponsavelCotacao##, está aguardando por sua aprovação. 
                    </p>
                    <p>
                        ID: ##idCotacao##
                        <br/>
                        e-mail: ##emailResponsavelCotacao##
                    </p>            
                    <p>
                        Para visualizar mais detalhes acesse a área de Análise de cotação no MyPardini utilizando suas credenciais.
                    </p>
                  </body>
                </html>";
    }
}
