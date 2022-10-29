namespace ParkingLot
{
    public class Car
    {
        private string licensePlate;

        public Car(string licensePlate)
        {
            this.licensePlate = licensePlate;
        }

        public string LicensePlate
        {
            get { return licensePlate; }
        }
    }
}