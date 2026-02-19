using System.Net;
using System.Net.Mail;

namespace Vehicle_Expense_Tracker.Services
{
    public class AdminEmailServices
    {
        private readonly IConfiguration _configuration;

        public AdminEmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendCredentials(string Email, string fullName, string password)
        {
            // ✅ Read from appsettings.json
            var fromEmail = _configuration["EmailSettings:FromEmail"];
            var appPassword = _configuration["EmailSettings:AppPassword"];
            var smtpHost = _configuration["EmailSettings:SmtpHost"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);

            var message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(Email);
            message.Subject = "Admin Login Credentials";
            message.Body = $@"
Hello {fullName},

Your Admin account has been created.

Login Email: {Email}
Password: {password}

Please change your password after first login.
";

            var smtp = new SmtpClient(smtpHost, port)
            {
                Credentials = new NetworkCredential(fromEmail, appPassword),
                EnableSsl = true
            };

            smtp.Send(message);
        }
    }
}

    

