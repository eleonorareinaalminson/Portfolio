using System.Net;
using System.Net.Mail;
using Portfolio.Web.Models;

namespace Portfolio.Web.Services;

public interface IEmailService
{
    Task<bool> SendContactEmailAsync(ContactMessage contactMessage);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<bool> SendContactEmailAsync(ContactMessage contactMessage)
    {
        try
        {
            var smtpHost = _configuration["Email:SmtpHost"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
            var smtpUsername = _configuration["Email:SmtpUsername"];
            var smtpPassword = _configuration["Email:SmtpPassword"];
            var fromEmail = _configuration["Email:FromEmail"];
            var fromName = _configuration["Email:FromName"];
            var toEmail = _configuration["Email:ToEmail"];

            using var client = new SmtpClient(smtpHost, smtpPort);
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            var subject = $"Ny kontakt från portfolio: {contactMessage.Subject}";

            var htmlBody = $@"
                    <html>
                    <body>
                        <h2>Nytt meddelande från ditt portfolio</h2>
                        <p><strong>Från:</strong> {contactMessage.Name}</p>
                        <p><strong>E-post:</strong> {contactMessage.Email}</p>
                        <p><strong>Ämne:</strong> {contactMessage.Subject}</p>
                        <p><strong>Meddelande:</strong></p>
                        <div style='background-color: #f8f9fa; padding: 15px; border-left: 4px solid #007bff; margin: 10px 0;'>
                            {contactMessage.Message.Replace("\n", "<br>")}
                        </div>
                        <hr>
                        <p><small style='color: #6c757d;'>Detta meddelande skickades från ditt portfolio kontaktformulär.</small></p>
                    </body>
                    </html>
                ";

            using var message = new MailMessage();
            message.From = new MailAddress(fromEmail!, fromName);
            message.To.Add(toEmail!);
            message.Subject = subject;
            message.Body = htmlBody;
            message.IsBodyHtml = true;

            // Sätt reply-to till avsändarens e-post för enklare svar
            message.ReplyToList.Add(new MailAddress(contactMessage.Email, contactMessage.Name));

            await client.SendMailAsync(message);

            _logger.LogInformation("E-post skickad framgångsrikt till {ToEmail} från {FromEmail}", toEmail, contactMessage.Email);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fel vid skickande av e-post från {Email}", contactMessage.Email);
            return false;
        }
    }
}