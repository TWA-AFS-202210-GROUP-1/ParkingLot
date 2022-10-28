using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace ParkingLotService
{
    public class ParkingLot
    {
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
            Cars.Add(car);
            return true;
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
    }
}
