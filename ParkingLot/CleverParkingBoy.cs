using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotSystem
{
    public class CleverParkingBoy : ParkingBoy
    {
        private List<ParkingLot> parkingLots;
        public CleverParkingBoy() : base()
        {
        }

        public ParkResponse<Ticket> HelpParkCar(Car car)
        {
            parkingLots.OrderByDescending(_ => _.Capacity).ToList();
            return base.HelpParkCar(car);
        }

        public List<ParkResponse<Ticket>> HelpParkCar(List<Car> carsList)
        {
            parkingLots.OrderByDescending(_ => _.Capacity).ToList();
            return base.HelpParkCar(carsList);
        }
    }
}