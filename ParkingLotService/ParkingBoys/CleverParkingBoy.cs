using System.Collections.Generic;
using System.Linq;

namespace ParkingLotService.ParkingBoys
{
    public class CleverParkingBoy : ParkingBoy
    {
        public CleverParkingBoy(string name) : base(name)
        {
        }

        public override Response<Ticket> ParkCar(Car car)
        {
            SortParkingLot();
            return base.ParkCar(car);
        }

        public override List<Response<Ticket>> ParkCars(List<Car> cars)
        {
            SortParkingLot();
            return base.ParkCars(cars);
        }

        private void SortParkingLot()
        {
            ManagingLots = ManagingLots.OrderByDescending(_ => _.MaxCapacity - _.CarCount).ToList();
        }
    }
}
