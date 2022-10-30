namespace ParkingLot
{
    public class Ticket
    {
        private string carId;
        private string parkingLotId;
        private string parkingBoyId;

        public Ticket(string carId, string parkingLotId, string parkingBoyId)
        {
            this.carId = carId;
            this.parkingLotId = parkingLotId;
            this.parkingBoyId = parkingBoyId;
        }

        public string CarId
        {
            get { return carId; }
            set { carId = value; }
        }

        public string ParkingLotId
        {
            get { return parkingLotId; }
            set { parkingLotId = value; }
        }

        public string ParkingBoyId
        {
            get { return parkingBoyId; }
            set { parkingBoyId = value; }
        }
    }
}