using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp; // You can remove this if you don't need dynamic type in .NET Standard frends Tasks
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Collections.Generic;

#pragma warning disable 1591

namespace Frends.SendGrid
{
    public static class Email
    {
        /// <summary>
        /// This task sends email via SendGrid API
        /// Documentation: https://github.com/GlazowskiHIQ/Frends.SendGrid
        /// </summary>
        /// <param name="input">What to repeat.</param>
        /// <param name="options">Define if repeated multiple times. </param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Replication} </returns>
        public static async Task<Result> Send(Parameters input, CancellationToken cancellationToken)
        {

            var message = new SendGridMessage();

            foreach (string recipient in input.Recipients)
            {
                message.AddTo(new EmailAddress(recipient));
            }

            message.SetFrom(new EmailAddress(input.Sender));

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