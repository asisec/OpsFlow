namespace OpsFlow.Core.Exceptions
{
    public sealed class ConfigurationException : Exception
    {
        public ConfigurationException(string message)
            : base(message)
        {
        }

        public ConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

