using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace ParkingLotService
{
    public class ParkingLot
    {
        private const int DefaultCapacity = 10;
        private int _capacity = DefaultCapacity;
        public int CarNumber { get; private set; } = 0;
        public List<Car> Cars { get; }
        public string Name { get; }

        public ParkingBoy ParkingBoy { get; set; }

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

        private bool IsLotFull()
        {
            return CarNumber < _capacity;
        }
    }
}
