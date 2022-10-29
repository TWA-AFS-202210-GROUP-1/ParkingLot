namespace ParkingLot
{
    public class FetchResult
    {
        public Car car { get; set; }
        public string message { get; set; }

        public FetchResult(Car car, string message)
        {
            this.car = car;
            this.message = message;
        }
    }
}