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

        public string FetchCar(Ticket ticket)
        {
            var licensePlate = ticket.LicensePlate;
            var deleteCar = carLot.DeleteCar(new Car(licensePlate));

            if (deleteCar != null)
            {
                return licensePlate;
            }

            return null;
        }

        public string FetchCar()
        {
            return null;
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

        public List<string> FetchManyCars(List<Ticket> ticketList)
        {
            var licensePlateList = new List<string>();
            foreach (var ticket in ticketList)
            {
                licensePlateList.Add(FetchCar(ticket));
            }

            return licensePlateList;
        }

    }
}
