namespace RBS.Application.Exceptions
{
    public class InvalidTokenException : ApplicationException
    {
        private string token;

        public InvalidTokenException(string token)
        {
            this.token = token;
        }
    }
}
