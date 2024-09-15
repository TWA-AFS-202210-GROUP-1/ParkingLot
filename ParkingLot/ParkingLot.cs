using System;
using System.Collections.Generic;

namespace ParkingLotSystem
{
    public class ParkingLot
    {
        private int capacity;
        private string lotId;
        private List<Car> cars;
        public ParkingLot(string lotId)
        {
            this.Capacity = 10;
            this.LotId = lotId;
            this.Cars = new List<Car>();
        }

        public ParkingLot(int capacity, string lotId)
        {
            this.Capacity = capacity;
            this.LotId = lotId;
            this.Cars = new List<Car>();
        }

        public string LotId { get => lotId; set => lotId = value; }
        public List<Car> Cars { get => cars; set => cars = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public void AddCar(Car car)
        {
            this.Cars.Add(car);
        }

        public bool IsAvailable()
        {
            return this.Capacity - cars.Count > 0;
        }

        public void RemoveCar(Car car)
        {
           this.Cars.Remove(car);
        }
    }
}