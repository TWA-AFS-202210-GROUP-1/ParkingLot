using System;

namespace ParkingLot
{
    public class Ticket
    {
        private string carId;
        private string parkingLotId;
        private string parkingBoyId;
        private bool hasBeenUsed;

        public Ticket(string carId, string parkingLotId, string parkingBoyId, bool hasBeenUsed = true)
        {
            this.carId = carId;
            this.parkingLotId = parkingLotId;
            this.parkingBoyId = parkingBoyId;
            this.hasBeenUsed = hasBeenUsed;
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

        public bool HasBeenUsed
        {
            get { return hasBeenUsed; }
            set { hasBeenUsed = value; }
        }
    }
}