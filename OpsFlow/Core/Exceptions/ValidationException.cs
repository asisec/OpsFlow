using System;
using System.Collections.Generic;
using System.Text;

namespace OpsFlow.Core.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {

        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
