namespace _10Aug.Exceptions
{
    public class SeatAlreadyBookedException : Exception
    {
        public SeatAlreadyBookedException(string message)
           : base(message)
        {
        }
    }
}
