namespace OpsFlow.Core.Exceptions
{
    public sealed class ResourceException : Exception
    {
        public ResourceException(string message)
            : base(message)
        {
        }

        public ResourceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}