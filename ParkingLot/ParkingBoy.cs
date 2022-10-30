using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ParkingLot
{
    using System;
    using System.Net.Sockets;

    public class ParkingBoy
    {
        private CarLot carLot;
        public List<CarLot> carLotList { get; set; }
        public ParkingBoy()
        {
            carLot = new CarLot(null);
            carLotList = new List<CarLot>();
        }

        public virtual BoyActionResult<Ticket> ParkCar(Car car)
        {
            foreach (var carLot in carLotList)
            {
                if (carLot.AddCar(car))
                {
                    var ticket = new Ticket(car.LicensePlate, carLot.lotId);
                    return new BoyActionResult<Ticket>(ticket, null);
                }
            }

            return new BoyActionResult<Ticket>(null, "Not enough position.");
        }

        public BoyActionResult<Car> FetchCar(Ticket ticket)
        {
            if (ticket == null || ticket.Used)
            {
                return new BoyActionResult<Car>(null, "Please provide your parking ticket.");
            }

            var licensePlate = ticket.LicensePlate;

            foreach (var carLot in carLotList)
            {
                var deleteCar = carLot.DeleteCar(new Car(licensePlate));
                if (deleteCar != null)
                {
                    ticket.Used = true;
                    ticket.lotId = carLot.lotId;
                    return new BoyActionResult<Car>(deleteCar, null);
                }
            }

            return new BoyActionResult<Car>(null, "Unrecognized parking ticket.");
        }

        public List<Ticket> ParkManyCars(List<Car> carList)
        {
            var ticketList = new List<Ticket>();
            foreach (var car in carList)
            {
                var boyActionResult = ParkCar(car);
                ticketList.Add(boyActionResult.subject);
            }

            return ticketList;
        }

        public List<Car> FetchManyCars(List<Ticket> ticketList)
        {
            var carList = new List<Car>();
            foreach (var ticket in ticketList)
            {
                carList.Add(FetchCar(ticket).subject);
            }

            return carList;
        }

        public void ManageParkingLots(CarLot carLot)
        {
            carLotList.Add(carLot);
        }
    }
}
