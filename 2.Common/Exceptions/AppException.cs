using System;

namespace SinsajoServices.Common.Exceptions
{
    /// <summary>
    /// Model App Exception, used to send Bad Request as response
    /// </summary>
    public class AppException : Exception
    {
        public AppException(string message)
            : base(message)
        {
        }        
    }
}