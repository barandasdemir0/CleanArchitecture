using CleanArchitecture.Application.Services;
using GenericEmailService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        // DÜZELTME 1: "async" kelimesi eklendi.
        // DÜZELTME 2: "string subject" parametresi eklendi (eksikti).
        // "IList<string>" yerine "List<string>" yazın
        public async Task SendMailAsync(List<string> emails, string subject, string body, List<Attachment>? attachments = null)
        {
            // 1. Ayarlar
            EmailConfigurations configurations = new(
                Smtp: "smtp.gmail.com",
                Password: "abcd efgh ijkl mnop", // Uygulama Şifreniz
                Port: 587,
                SSL: true,
                Html: true
            );

            // 2. Model
            EmailModel<Attachment> model = new(
                Configurations: configurations,
                FromEmail: "seninmailadresin@gmail.com",
                ToEmails: emails.ToList(), // IList'i List'e çeviriyoruz
                Subject: subject,          // Artık hata vermez
                Body: body,
                Attachments: attachments
            );

            // 3. Gönderim
            await EmailService.SendEmailWithNetAsync(model);
        }

    }
}
