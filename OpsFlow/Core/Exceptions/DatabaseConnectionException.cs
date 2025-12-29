namespace OpsFlow.Core.Exceptions
{
    public sealed class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message)
            : base(message)
        {

        }

        public DatabaseConnectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}