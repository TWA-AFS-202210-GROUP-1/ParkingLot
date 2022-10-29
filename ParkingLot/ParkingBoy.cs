using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        private CarLot carLot;

        public ParkingBoy()
        {
            carLot = new CarLot("lotID");
        }

        public Ticket ParkCar(Car car)
        {
            if (carLot.AddCar(car))
            {
                return new Ticket(car.LicensePlate, "lotID");
            }

            return null;
        }

        public FetchResult FetchCar(Ticket ticket)
        {
            if (ticket == null || ticket.Used)
            {
                return null;
            }

            var licensePlate = ticket.LicensePlate;
            var deleteCar = carLot.DeleteCar(new Car(licensePlate));

            if (deleteCar != null)
            {
                ticket.Used = true;
                return new FetchResult(deleteCar, "aaa");
            }

            var fetchResult = new FetchResult(null, "Unrecognized parking ticket.");
            return fetchResult;
        }

        public List<Ticket> ParkManyCars(List<Car> carList)
        {
            var ticketList = new List<Ticket>();
            foreach (var car in carList)
            {
                var ticket = ParkCar(car);
                ticketList.Add(ticket);
            }

            return ticketList;
        }

        public List<Car> FetchManyCars(List<Ticket> ticketList)
        {
            var carList = new List<Car>();
            foreach (var ticket in ticketList)
            {
                carList.Add(FetchCar(ticket).car);
            }

            return carList;
        }
    }
}
