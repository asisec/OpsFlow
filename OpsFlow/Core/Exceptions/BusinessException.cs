namespace OpsFlow.Core.Exceptions
{
    public sealed class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {

        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}