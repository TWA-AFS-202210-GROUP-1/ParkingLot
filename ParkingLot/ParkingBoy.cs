using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ParkingLot
{
    using System;
    using System.Net.Sockets;

    public class ParkingBoy
    {
        private CarLot carLot;

        public ParkingBoy()
        {
            carLot = new CarLot("lotID");
        }

        public BoyActionResult<Ticket> ParkCar(Car car)
        {
            if (carLot.AddCar(car))
            {
                var ticket = new Ticket(car.LicensePlate, "lotID");
                return new BoyActionResult<Ticket>(ticket, null);
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
            var deleteCar = carLot.DeleteCar(new Car(licensePlate));

            if (deleteCar != null)
            {
                ticket.Used = true;
                return new BoyActionResult<Car>(deleteCar, null);
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
    }
}
