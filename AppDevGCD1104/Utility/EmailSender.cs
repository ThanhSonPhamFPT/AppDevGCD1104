using Microsoft.AspNetCore.Identity.UI.Services;

namespace AppDevGCD1104.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Add email sending logic
            return Task.CompletedTask;
        }
    }
}
