using System;
using System.Collections.Generic;

namespace ParkingLotSystem
{
    public class ParkingBoy
    {
        private TicketNumGenerator ticketNumGenerator;
        private List<Ticket> ticketsList;
        private ParkingLot parkingLot;
        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
            this.ticketsList = new List<Ticket>();
        }

        public List<Ticket> TicketsList { get => ticketsList; set => ticketsList = value; }

        public Ticket HelpParkCar(string carNum)
        {
            if (parkingLot.IsAvailable())
            {
                this.ticketNumGenerator = new TicketNumGenerator();
                Ticket ticket = new Ticket(carNum, ticketNumGenerator);
                this.TicketsList.Add(ticket);
                parkingLot.AddCar();
                return ticket;
            }
            else
            {
                throw new Exception("Not enough position.");
            }
        }

        public List<Ticket> HelpParkCar(List<string> carsList)
        {
            List<Ticket> tickets = new List<Ticket>();
            this.ticketNumGenerator = new TicketNumGenerator();
            foreach (string car in carsList)
            {
                if (parkingLot.IsAvailable())
                {
                    Ticket ticket = new Ticket(car, ticketNumGenerator);
                    this.TicketsList.Add(ticket);
                    tickets.Add(ticket);
                    parkingLot.AddCar();
                }
                else
                {
                    throw new Exception("Not enough position.");
                }
            }

            return tickets;
        }

        public string HelpFetchCar()
        {
            throw new Exception("Please provide your parking ticket.");
        }

        public string HelpFetchCar(Ticket ticket)
        {
            string fetchCarRes = string.Empty;
            if (ticketsList.Contains(ticket))
            {
                fetchCarRes = ticket.CarNum;
                ticketsList.Remove(ticket);
                parkingLot.RemoveCar();
                return fetchCarRes;
            }
            else
            {
                throw new Exception("Unrecognized parking ticket.");
            }
        }
    }
}