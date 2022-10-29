using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class CarLot
    {
        private string lotID;

        public CarLot(string lotID)
        {
            this.lotID = lotID;
            this.CarList = new List<Car>();
        }

        public List<Car> CarList { get; }

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
                    CarList.Remove(existedCar);
                    return existedCar;
                }
            }

            return null;
        }
    }
}
