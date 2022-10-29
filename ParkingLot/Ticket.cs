namespace ParkingLot
{
    public class Ticket
    {
        private string licensePlate;
        private string lotID;
        public Ticket(string licensePlate, string lotID)
        {
            this.licensePlate = licensePlate;
            this.lotID = lotID;
        }

        public string LicensePlate
        {
            get { return licensePlate; }
        }
    }
}