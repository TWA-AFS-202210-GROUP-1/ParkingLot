namespace ParkingLot
{
    public class Ticket
    {
        public string licensePlate;
        private int lotNo;
        public Ticket(string licensePlate, int lotNo)
        {
            this.licensePlate = licensePlate;
            this.lotNo = lotNo;
        }

        public string LicensePlate
        {
            get { return licensePlate; }
        }
    }
}