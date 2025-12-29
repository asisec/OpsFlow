namespace OpsFlow.Core.Exceptions
{
    public sealed class AuthenticationException : Exception
    {
        public AuthenticationException(string message)
            : base(message)
        {

        }

        public AuthenticationException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}