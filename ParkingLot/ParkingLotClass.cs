namespace ParkingLot
{
    public class ParkingLotClass
    {
        private string parkingLotName;

        public ParkingLotClass(string parkingLotName)
        {
            this.parkingLotName = parkingLotName;
        }

        public string ParkingLotName
        {
            get { return parkingLotName; }
        }
    }
}