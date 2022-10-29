namespace ParkingLot
{
    public class Car
    {
        public string LicensePlate { get; set; }
        public Car(string licensePlate)
        {
            this.LicensePlate = licensePlate;
        }
    }
}