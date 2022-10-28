using System.Collections.Generic;
using ParkingLotService.Const;
using System.Linq;

namespace ParkingLotService.ParkingBoys
{
    public class CleverParkingBoy : ParkingBoy
    {
        private bool canSort = true;
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
            canSort = false;
            var responses = base.ParkCars(cars);
            canSort = true;
            return responses;
        }

        private void SortParkingLot()
        {
            if (canSort)
            {
                ManagingLots = ManagingLots.OrderByDescending(_ => _.MaxCapacity - _.CarNumber).ToList();
            }
        }
    }
}
