namespace ParkingLot
{
    public class Ticket
    {
        public string LotId;
        public string LicensePlate;
        public bool Used;

        public Ticket(string licensePlate, string lotId)
        {
            this.LicensePlate = licensePlate;
            this.LotId = lotId;
            this.Used = false;
        }
    }
}