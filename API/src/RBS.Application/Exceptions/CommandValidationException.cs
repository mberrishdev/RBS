namespace RBS.Application.Exceptions
{
    public class CommandValidationException : ApplicationException
    {
        public CommandValidationException(string msg) : base(msg)
        {

        }
    }
}
