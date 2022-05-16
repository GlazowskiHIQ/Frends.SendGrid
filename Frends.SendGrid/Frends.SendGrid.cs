using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp; // You can remove this if you don't need dynamic type in .NET Standard frends Tasks
using SendGrid.Helpers.Mail;
using SendGrid;

#pragma warning disable 1591

namespace Frends.SendGrid
{
    public static class Email
    {
        /// <summary>
        /// This task sends email via SendGrid API 
        /// 
        /// Documentation: https://github.com/GlazowskiHIQ/Frends.SendGrid
        /// </summary>
        /// <param name="input">Email parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Result: {string Body, string StatusCode, string Headers} </returns>
        public static async Task<Result> SendEmail(Parameters input, CancellationToken cancellationToken)
        {

            var message = new SendGridMessage();

            foreach (string singleEntry in input.Recipients)
            {
                foreach(string recipient in singleEntry.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
                message.AddTo(new EmailAddress(recipient.Trim()));
            }

            message.SetFrom(new EmailAddress(input.Sender));

            message.SetSubject(input.Subject);

            message.AddContent("text/html", input.Message);

            foreach (Attachments attachment in input.Attachments)
            {
                message.AddAttachment(attachment.FileName, attachment.Content, attachment.ContentType);
            };

            message.MailSettings = new MailSettings()
            {
                BypassListManagement = new BypassListManagement()
                {
                    Enable = false
                },
                FooterSettings = new FooterSettings()
                {
                    Enable = false
                },
                SandboxMode = new SandboxMode()
                {
                    Enable = false
                }
            };

            message.TrackingSettings = new TrackingSettings()
            {
                ClickTracking = new ClickTracking()
                {
                    Enable = true,
                    EnableText = false
                },
                OpenTracking = new OpenTracking()
                {
                    Enable = true,
                    SubstitutionTag = "%open-track%"
                },
                SubscriptionTracking = new SubscriptionTracking()
                {
                    Enable = false
                }
            };

            cancellationToken.ThrowIfCancellationRequested();

            var client = new SendGridClient(input.AuthorizationToken);
            var response = await client.SendEmailAsync(message).ConfigureAwait(false);

            var result = new Result
            {
                Body = response.Body.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode.ToString(),
                Headers = response.Headers.ToString()
            };

            return result;
        }
    }
}