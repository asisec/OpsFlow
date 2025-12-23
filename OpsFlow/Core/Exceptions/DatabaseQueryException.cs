using System;
using System.Collections.Generic;
using System.Text;

namespace OpsFlow.Core.Exceptions
{
    public sealed class DatabaseQueryException : Exception
    {
        public DatabaseQueryException(string message)
            : base(message)
        {

        }

        public DatabaseQueryException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
