using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CSharp; // You can remove this if you don't need dynamic type in .NET Standard frends Tasks
using SendGrid.Helpers.Mail;

#pragma warning disable 1591

namespace Frends.SendGrid
{
    public static class Email
    {
        /// <summary>
        /// This is task
        /// Documentation: https://github.com/CommunityHiQ/Frends.SendGrid
        /// </summary>
        /// <param name="input">What to repeat.</param>
        /// <param name="options">Define if repeated multiple times. </param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Replication} </returns>
        public static async Task<Result> Send(Parameters input, [PropertyTab] Options options, CancellationToken cancellationToken)
        {

            var message = new SendGridMessage();

            

            return null;
        }
    }
}
