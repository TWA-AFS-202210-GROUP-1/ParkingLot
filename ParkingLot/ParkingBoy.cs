using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string parkingBoyName;
        private List<Ticket> hadBeenParkedCarTicketList;

        public ParkingBoy(string parkingBoyName)
        {
            this.parkingBoyName = parkingBoyName;
            this.hadBeenParkedCarTicketList = new List<Ticket>();
        }

        public Car FetchingCar(Ticket ticket)
        {
            if (hadBeenParkedCarTicketList.Contains(ticket))
            {
                if (ticket.HasBeenUsed == false)
                {
                    ticket.HasBeenUsed = true;
                    return new Car(ticket.CarId);
                }
                else
                {
                    throw new ArgumentException("Ticket has already been used, can't fetch car.");
                }
            }
            else
            {
                throw new ArgumentException("Invalid Ticket, can't fetch car.");
            }
        }

        public Ticket ParkingCar(Car car, ParkingLotClass parkingLot)
        {
            Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
            hadBeenParkedCarTicket.HasBeenUsed = false;
            hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
            return hadBeenParkedCarTicket;
        }

        public List<Ticket> ParkingCar(List<Car> carList, ParkingLotClass parkingLot)
        {
            foreach (Car car in carList)
            {
                hadBeenParkedCarTicketList.Add(new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName));
            }

            return hadBeenParkedCarTicketList;
        }
    }
}