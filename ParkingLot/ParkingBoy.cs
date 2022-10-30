using System;
using System.Collections.Generic;
using System.Linq;
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
            if (parkingLot.ParkingLotCapacity > 0)
            {
                Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
                hadBeenParkedCarTicket.HasBeenUsed = false;
                hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                parkingLot.ParkingLotCapacity--;
                return hadBeenParkedCarTicket;
            }
            else
            {
                throw new ArgumentException("Not enough position.");
            }
        }

        public List<Ticket> ParkingCar(List<Car> carList, ParkingLotClass parkingLot)
        {
            foreach (Car car in carList)
            {
                if (parkingLot.ParkingLotCapacity > 0)
                {
                    Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
                    hadBeenParkedCarTicket.HasBeenUsed = false;
                    hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                    parkingLot.ParkingLotCapacity--;
                }
                else
                {
                    throw new ArgumentException("Not enough position.");
                }
            }

            return hadBeenParkedCarTicketList;
        }

        public List<Ticket> ParkingCar(List<Car> carList, List<ParkingLotClass> parkingLotList)
        {
            int maxCapacityForParkingLot = 3;
            foreach (Car car in carList)
            {
                int chooseParkingLotIndex = carList.IndexOf(car) / maxCapacityForParkingLot;
                if (chooseParkingLotIndex < parkingLotList.Count)
                {
                    Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, parkingLotList[chooseParkingLotIndex].ParkingLotName, parkingBoyName);
                    hadBeenParkedCarTicket.HasBeenUsed = false;
                    hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                    parkingLotList[chooseParkingLotIndex].ParkingLotCapacity--;
                }
                else
                {
                    throw new ArgumentException("Not enough position.");
                }
            }

            return hadBeenParkedCarTicketList;
        }
    }
}