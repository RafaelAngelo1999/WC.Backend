using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Shared.Util
{
    public static class Constantes
    {
        public static class Email
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
                       Olá, ##destinatario##
                    </p>
                    <p>
                        Ja foram extraidos ##quantidadeExtraida## dos ##quantidadeRegistro## produtos mapeados nas tabelas, cerca de ##porcetagemExtraida##.  
                    </p>          
                    <p>
                         Para visualizar mais detalhes acesse o DashBoard.
                    </p>
                  </body>
                </html>";
        }
    }
}
