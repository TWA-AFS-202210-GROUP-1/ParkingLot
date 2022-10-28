using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using ParkingLotService.Const;
using ParkingLotService.ParkingBoys;

namespace ParkingLotService
{
    public class ParkingLot
    {
        public int MaxCapacity { get; private set; } = ParkingLotConst.DefaultCapacity;
        public int CarNumber { get; private set; } = 0;
        public List<Car> Cars { get; }
        public string Name { get; }

        public ParkingLot(string name)
        {
            Name = name;
            Cars = new List<Car>();
        }

        public bool AddCar(Car car)
        {
            if (IsLotFull())
            {
                Cars.Add(car);
                CarNumber++;
                return true;
            }

            return false;
        }

        public Car PopCar(string licenseNumber)
        {
            var car = Cars.Find(_ => _.LicenseNumber.Equals(licenseNumber));
            if (car != null)
            {
                Cars.Remove(car);
            }

            return car;
        }

        public void SeMaxCapacity(int max)
        {
            MaxCapacity = max;
        }

        private bool IsLotFull()
        {
            return CarNumber < MaxCapacity;
        }
    }
}
