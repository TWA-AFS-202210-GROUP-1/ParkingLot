using System;

namespace ParkingLotSystem
{
    public class ParkingLot
    {
        private string lotNum;
        private int capacity;
        private int availabeSpotNum;
        public ParkingLot()
        {
            this.lotNum = Guid.NewGuid().ToString();
            this.capacity = 10;
            this.availabeSpotNum = 10;
        }

        public ParkingLot(int capacity)
        {
            this.lotNum = Guid.NewGuid().ToString();
            this.capacity = capacity;
            this.availabeSpotNum = capacity;
        }

        public void AddCar()
        {
            this.availabeSpotNum--;
        }

        public bool IsAvailable()
        {
            return this.availabeSpotNum > 0;
        }

        public void RemoveCar()
        {
            this.availabeSpotNum++;
        }
    }
}