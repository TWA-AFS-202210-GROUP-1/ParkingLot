namespace ParkingLot
{
    public class ParkingLotClass
    {
        private string parkingLotName;
        private int parkinguLotCapacity;

        public ParkingLotClass(string parkingLotName)
        {
            this.parkingLotName = parkingLotName;
            parkinguLotCapacity = 3;
        }

        public string ParkingLotName
        {
            get { return parkingLotName; }
        }

        public int ParkingLotCapacity
        {
            get { return parkinguLotCapacity; }
            set { parkinguLotCapacity = value; }
        }
    }
}