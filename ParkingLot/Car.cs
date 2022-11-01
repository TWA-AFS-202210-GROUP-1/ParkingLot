using System;

namespace ParkingLotSystem
{
    public class Car
    {
        private string carNum;

        public Car(string carNum)
        {
            this.CarNum = carNum;
        }

        public string CarNum { get => carNum; set => carNum = value; }
    }
}