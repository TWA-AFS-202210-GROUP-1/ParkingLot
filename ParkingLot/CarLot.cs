using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class CarLot
    {
        public string LotId;
        public int Capacity;
        public List<Car> CarList;

        public CarLot(string lotId)
        {
            this.LotId = lotId;
            this.CarList = new List<Car>();
            this.Capacity = Constant.Capacity;
        }

        public bool AddCar(Car car)
        {
            if (CarList.Count < Capacity)
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
            foreach (var existedCar in CarList.Where(existedCar => existedCar.LicensePlate == car.LicensePlate))
            {
                CarList.Remove(existedCar);
                return existedCar;
            }

            return null;
        }
    }
}
