using ParkingLotService.Const;
using System.Collections.Generic;

namespace ParkingLotService
{
    public class ParkingLot
    {
        public int MaxCapacity { get; private set; } = ParkingLotConst.DefaultCapacity;

        public int CarCount => Cars.Count;

        public List<Car> Cars { get; }
        public string Name { get; }
        public bool IsNotFull => CarCount < MaxCapacity;

        public ParkingLot(string name)
        {
            Name = name;
            Cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
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

        public void SetMaxCapacity(int max)
        {
            MaxCapacity = max;
        }
    }
}
