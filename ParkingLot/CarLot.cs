using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class CarLot
    {
        public string lotId { get; set; }
        public int capacity { get; set; }
        public List<Car> CarList { get; set; }

        public CarLot(string lotId)
        {
            this.lotId = lotId;
            this.CarList = new List<Car>();
            this.capacity = 10;
        }

        public bool AddCar(Car car)
        {
            if (CarList.Count < capacity)
            {
                CarList.Add(car);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car DeleteCar(Car car)
        {
            foreach (var existedCar in CarList)
            {
                if (existedCar.LicensePlate == car.LicensePlate)
                {
                    CarList.Remove(existedCar);
                    return existedCar;
                }
            }

            return null;
        }
    }
}
