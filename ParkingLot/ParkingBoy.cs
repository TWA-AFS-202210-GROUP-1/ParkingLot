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
            if (hadBeenParkedCarTicketList.Contains(ticket) && ticket.HasBeenUsed == false)
            {
                    ticket.HasBeenUsed = true;
                    return new Car(ticket.CarId);
            }
            else
            {
                throw new ArgumentException("Unrecognized parking ticket.");
            }
        }

        public Car FetchingCar()
        {
            throw new ArgumentException("Please provide your parking ticket.");
        }

        public Ticket ParkingCar(Car car, ParkingLotClass parkingLot)
        {
            // need extract a method here about if else
            if (parkingLot.ParkinguLotCapacity > 0)
            {
                Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
                hadBeenParkedCarTicket.HasBeenUsed = false;
                hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                parkingLot.ParkinguLotCapacity--;
                return hadBeenParkedCarTicket;
            }
            else
            {
                throw new ArgumentException("Parking lot is undercapacity, can't parking car.");
            }
        }

        public List<Ticket> ParkingCar(List<Car> carList, ParkingLotClass parkingLot)
        {
            foreach (Car car in carList)
            {
                // need extract a method here about if else
                if (parkingLot.ParkinguLotCapacity > 0)
                {
                    Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
                    hadBeenParkedCarTicket.HasBeenUsed = false;
                    hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                    parkingLot.ParkinguLotCapacity--;
                }
                else
                {
                    throw new ArgumentException("Parking lot is undercapacity, can't parking car.");
                }
            }

            return hadBeenParkedCarTicketList;
        }
    }
}