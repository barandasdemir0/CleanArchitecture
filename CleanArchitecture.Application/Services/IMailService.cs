using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CleanArchitecture.Application.Services
{
    public interface IMailService
    {
        Task SendMailAsync(List<string> emails, string subject, string body, List<Attachment> attachments = null);
    }
}
