using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace ParkingLotService
{
    public class ParkingLot
    {
        private const int DefaultCapacity = 10;
        private int _capacity = DefaultCapacity;
        private int _carNumber = 0;
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
                _carNumber++;
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

        private void SetCapacity(int capacity)
        {
            _capacity = capacity;
        }

        private bool IsLotFull()
        {
            return _carNumber < _capacity;
        }
    }
}
