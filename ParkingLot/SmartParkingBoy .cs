using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public List<CarLot> carLotList { get; set; }
        private CarLot carLot;

        public SmartParkingBoy() : base()
        {
            carLotList = new List<CarLot>();
            carLot = new CarLot(null);
        }

        public override BoyActionResult<Ticket> ParkCar(Car car)
        {
            var betterCarLot = new CarLot(" ");
            var count = 0;
            foreach (var carLot in carLotList)
            {
                var restPlace = carLot.capacity - carLot.CarList.Count;
                if (restPlace >= count)
                {
                    betterCarLot = carLot;
                    count = restPlace;
                }
            }

            if (betterCarLot.AddCar(car))
            {
                var ticket = new Ticket(car.LicensePlate, betterCarLot.lotId);
                return new BoyActionResult<Ticket>(ticket, null);
            }

            return new BoyActionResult<Ticket>(null, "Not enough position.");
        }

        public new void ManageParkingLots(CarLot carLot)
        {
            carLotList.Add(carLot);
        }
    }
}
