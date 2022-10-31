using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ParkingLot
{
    using System;
    using System.Net.Sockets;

    public class ParkingBoy
    {
        public List<CarLot> CarLotList;
        public ParkingBoy()
        {
            CarLotList = new List<CarLot>();
        }

        public virtual BoyActionResult<Ticket> ParkCar(Car car)
        {
            foreach (var carLot in CarLotList)
            {
                if (carLot.AddCar(car))
                {
                    var ticket = new Ticket(car.LicensePlate, carLot.LotId);
                    return new BoyActionResult<Ticket>(ticket, null);
                }
            }

            return new BoyActionResult<Ticket>(null, Constant.FullParkingLotMessage);
        }

        public BoyActionResult<Car> FetchCar(Ticket ticket)
        {
            if (ticket == null || ticket.Used)
            {
                return new BoyActionResult<Car>(null, Constant.UsedOrNullTicketMessage);
            }

            var licensePlate = ticket.LicensePlate;

            foreach (var carLot in CarLotList)
            {
                var deleteCar = carLot.DeleteCar(new Car(licensePlate));
                if (deleteCar != null)
                {
                    ticket.Used = true;
                    ticket.LotId = carLot.LotId;
                    return new BoyActionResult<Car>(deleteCar, null);
                }
            }

            return new BoyActionResult<Car>(null, Constant.InvalidMessage);
        }

        public List<Ticket> ParkManyCars(List<Car> carList)
        {
            return carList.Select(car => ParkCar(car)).Select(boyActionResult => boyActionResult.subject).ToList();
        }

        public List<Car> FetchManyCars(List<Ticket> ticketList)
        {
            return ticketList.Select(ticket => FetchCar(ticket).subject).ToList();
        }

        public void ManageParkingLots(CarLot carLot)
        {
            CarLotList.Add(carLot);
        }
    }
}
