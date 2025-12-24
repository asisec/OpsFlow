using System;

namespace OpsFlow.Core.Exceptions
{
    public class VerificationException : Exception
    {
        public VerificationException(string message) : base(message) { }
    }
}