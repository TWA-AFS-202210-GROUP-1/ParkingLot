namespace ParkingLot
{
    public class BoyActionResult<T>
    {
        public T subject { get; set; }
        public string message { get; set; }

        public BoyActionResult(T subject, string message)
        {
            this.subject = subject;
            this.message = message;
        }
    }
}