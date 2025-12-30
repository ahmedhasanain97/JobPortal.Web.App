namespace JobPortal.Application.Exceptions
{
    public class DataFailureException : Exception
    {
        public string ErrorDescription { get; private set; }
        public override string Message => $"An error occurd while processing your request, ErrorDescription= {ErrorDescription}.";

        public DataFailureException(string errorDescription) : base(errorDescription)
        {
            ErrorDescription = errorDescription;
        }
    }
}