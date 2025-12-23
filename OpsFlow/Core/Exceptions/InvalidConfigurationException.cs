using System;
using System.Collections.Generic;
using System.Text;

namespace OpsFlow.Core.Exceptions
{
    public sealed class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(string message)
            : base(message)
        {

        }

        public InvalidConfigurationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
