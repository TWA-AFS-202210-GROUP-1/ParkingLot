using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public List<CarLot> CarLotList;

        public SmartParkingBoy() : base()
        {
            CarLotList = new List<CarLot>();
        }

        public override BoyActionResult<Ticket> ParkCar(Car car)
        {
            var betterCarLot = new CarLot(" ");
            var count = 0;
            foreach (var carLot in CarLotList)
            {
                var restPlace = carLot.Capacity - carLot.CarList.Count;
                if (restPlace >= count)
                {
                    betterCarLot = carLot;
                    count = restPlace;
                }
            }

            if (betterCarLot.AddCar(car))
            {
                var ticket = new Ticket(car.LicensePlate, betterCarLot.LotId);
                return new BoyActionResult<Ticket>(ticket, null);
            }

            return new BoyActionResult<Ticket>(null, Constant.FullParkingLotMessage);
        }

        public new void ManageParkingLots(CarLot carLot)
        {
            CarLotList.Add(carLot);
        }
    }
}
