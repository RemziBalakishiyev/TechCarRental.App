namespace CarRental.Application.Extensions
{
    public class TehcCarException: ApplicationException
    {
        public TehcCarException(string message)
            : base($"Tech car exception: {message} ") 
        {
            
        }
    }
}
