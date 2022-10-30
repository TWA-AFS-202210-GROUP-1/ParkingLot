namespace ParkingLot
{
    public class Customer
    {
        private string carNum;

        public Customer(string carNum)
        {
            this.CarNum = carNum;
        }

        public string CarNum { get => carNum; set => carNum = value; }
    }
}