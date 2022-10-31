namespace ParkingLot
{
    public class Car
    {
        private string ownerName;

        public Car(string ownerName)
        {
            this.ownerName = ownerName;
        }

        public string OwnerName
        {
            get { return ownerName; }
        }
    }
}