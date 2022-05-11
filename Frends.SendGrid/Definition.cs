#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.SendGrid
{
    public class Recipients
    {
        public string Recipient { get; set; }
    }

    public class Attachments
    {
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string Content { get; set; }
    }


    /// <summary>
    /// Parameters class usually contains parameters that are required.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Something that will be repeated.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Options class provides additional optional parameters.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Number of times input is repeated.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// How repeats of the input are separated.
        /// </summary>
        public string Delimiter { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// Contains the input repeated the specified number of times.
        /// </summary>
        public string Replication;
    }
}
