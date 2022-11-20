namespace Common.Repository.Exceptions
{
    public class UnitOfWorkException : Exception
    {
        public UnitOfWorkException(string message) : base(message) { }
    }
}
