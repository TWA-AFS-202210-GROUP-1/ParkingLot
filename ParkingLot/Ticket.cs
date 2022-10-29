namespace ParkingLot
{
    public class Ticket
    {
        private string lotId;
        public string LicensePlate { get; set; }
        public bool Used { get; set; }

        public Ticket(string licensePlate, string lotId)
        {
            this.LicensePlate = licensePlate;
            this.lotId = lotId;
            this.Used = false;
        }
    }
}