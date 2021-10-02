using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.DTO.Email;
using WC.Domain.Interfaces;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Util;
using WC.Shared.Validacao;

namespace WC.Domain.Services
{
    public class EnvioEmailService : IEnvioEmailService
    {
        public EmailSettings _emailSettings { get; }


        public EnvioEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task EnviarEmailRotinaWebScrapingAsync()
        {

            string email = "rafaelangelowow@gmail.com";
            string subject = "FeedBack Scraping";

            string message = Constantes.Email.TEMPLATE_EMAIL_FEEDBACK
                .Replace("##destinatario##", "Rafael Angelo")
                .Replace("##quantidadeExtraida##", "2.000")
                .Replace("##quantidadeRegistro##", "18.000")
                .Replace("##porcetagemExtraida##", "80%");

            Execute(email, subject, message).Wait();

        }

        public async Task Execute(string email, string subject, string message)
        {

            string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.Username, "Status Scraping")
            };

            mail.To.Add(new MailAddress(toEmail));
            mail.CC.Add(new MailAddress(_emailSettings.CcEmail));
            mail.Body = message;
            mail.Subject = "Rotina de Feedback - " + subject;
            
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            //outras opções
            //mail.Attachments.Add(new Attachment(arquivo));
            //

            using (SmtpClient smtp = new SmtpClient(_emailSettings.Servidor, _emailSettings.Port))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
