using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class CarLot
    {
        private string LotID;
        public List<Car> CarList { get; }

        public CarLot(string lotID)
        {
            LotID = lotID;
            CarList = new List<Car>();
        }

        public bool AddCar(Car car)
        {
            CarList.Add(car);
            return true;
        }

        public Car DeleteCar(Car car)
        {
            foreach (var existedCar in CarList)
            {
                if (existedCar.LicensePlate == car.LicensePlate)
                {
                    CarList.Remove(car);
                    return car;
                }
            }

            return null;
        }
    }
}
