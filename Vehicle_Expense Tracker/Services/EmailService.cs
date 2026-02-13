using System.Net;
using System.Net.Mail;

namespace Vehicle_Expense_Tracker.Services
{
    public class EmailService
    {      
        public void SendCredentials(string Email, string fullName, string password)
        {
            var fromEmail = "godaryashra@gmail.com";
            var appPassword = "brpr ryxy iphw ouno";

            var message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(Email);
            message.Subject = "Staff Login Credentials";
            message.Body = $@"
Hello {fullName},

Your staff account has been created.

Login Email: {Email}
Password: {password}

Please change your password after first login.
";

            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, appPassword),
                EnableSsl = true
            };

            smtp.Send(message);
        }
        }
    }
