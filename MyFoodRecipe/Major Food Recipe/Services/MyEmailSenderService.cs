using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Major_Food_Recipe.Services
{
    public class MyEmailSenderService
        : IEmailSender
    {
        private readonly ILogger<MyEmailSenderService> _logger;

        public MyEmailSenderService(ILogger<MyEmailSenderService> logger)
        {
            _logger = logger;
        }

        #region Microsoft.AspNetCore.Identity.UI.Services.IEmailSender members
        public Task SendEmailAsync(string emailAddress, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Email sent to : {emailAddress}, MsgContent: {htmlMessage}");
            return Task.CompletedTask;
        }
        #endregion
    }
}
