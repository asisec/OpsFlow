namespace OpsFlow.Core.Exceptions
{
    public sealed class FileUploadException : Exception
    {
        public FileUploadException(string message)
            : base(message)
        {
        }

        public FileUploadException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

