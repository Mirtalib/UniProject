using Application.Models.Config;
using Application.Services;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Services;

public class MailService : IMailService
{
    private readonly SMTPConfig _config;

    public MailService(SMTPConfig configuration)
    {
        _config = configuration;
    }

    public void NotifyOtherNew(string email, string message)
    {
        using var client = new SmtpClient()
        {
            Host = _config.Host,
            Port = _config.Port,
            EnableSsl = _config.EnableSsl,
            Credentials = new NetworkCredential(_config.Username, _config.Password)
        };

        using var mailMessage = new MailMessage()
        {
            IsBodyHtml = true,
            Subject = $"{message}",
            Body = $@"<h1>{message}</h1>"
        };

        mailMessage.From = new MailAddress(_config.Username);
        mailMessage.To.Add(new MailAddress(email));

        client.Send(mailMessage);
    }

    public void SendExamFailMessage(string email)
    {
        using var client = new SmtpClient()
        {
            Host = _config.Host,
            Port = _config.Port,
            EnableSsl = _config.EnableSsl,
            Credentials = new NetworkCredential(_config.Username, _config.Password)
        };

        using var message = new MailMessage()
        {
            IsBodyHtml = true,
            Subject = "Your exam has failed...",
            Body = $@"<h1>Your Exam has failed in university</h1>"
        };

        message.From = new MailAddress(_config.Username);
        message.To.Add(new MailAddress(email));

        client.Send(message);
    }


    public void SendOverLimitMessage(string email)
    {
        using var client = new SmtpClient()
        {
            Host = _config.Host,
            Port = _config.Port,
            EnableSsl = _config.EnableSsl,
            Credentials = new NetworkCredential(_config.Username, _config.Password)
        };

        using var message = new MailMessage()
        {
            IsBodyHtml = true,
            Subject = "Your attention limit on lessons is over...",
            Body = $@"<h1>Your attention limit on lessons is over</h1>"
        };

        message.From = new MailAddress(_config.Username);
        message.To.Add(new MailAddress(email));

        client.Send(message);
    }
}
