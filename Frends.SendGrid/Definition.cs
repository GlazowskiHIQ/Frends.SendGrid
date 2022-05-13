#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.SendGrid
{
  
    public class Attachments
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
    }

    public class Parameters
    {
       public string AuthorizationToken { get; set; }
        public string Sender { get; set; }
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public Attachments[] Attachments { get; set; }

    }

    public class Result
    {
        public string StatusCode { get; set; }
        public string Body { get; set; }
        public string Headers { get; set; }
    }
}
