// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Example
{
    internal class Example
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGrid.TC3EF6.WebForms.APIKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kfc12@comcast.net", "TC3EF6.WebForms WebMaster");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("kfc12@outlook.com", "Test E-mail");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
