using System;
using System.Collections.Generic;
using System.Text;

namespace OpsFlow.Core.Exceptions
{
    public sealed class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) 
            : base(message)
        {

        }
    }
}
