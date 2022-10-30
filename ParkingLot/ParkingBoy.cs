using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private TicketNumGenerator ticketNumGenerator;
        private List<Ticket> ticketsList;
        public ParkingBoy()
        {
            this.ticketsList = new List<Ticket>();
        }

        public List<Ticket> TicketsList { get => ticketsList; set => ticketsList = value; }

        public Ticket HelpParkCar(string carNum)
        {
            this.ticketNumGenerator = new TicketNumGenerator();
            Ticket ticket = new Ticket(carNum, ticketNumGenerator);
            this.TicketsList.Add(ticket);
            return ticket;
        }

        public List<Ticket> HelpParkCar(List<string> carsList)
        {
            List<Ticket> tickets = new List<Ticket>();
            this.ticketNumGenerator = new TicketNumGenerator();
            foreach (string car in carsList)
            {
                Ticket ticket = new Ticket(car, ticketNumGenerator);
                this.TicketsList.Add(ticket);
                tickets.Add(ticket);
            }

            return tickets;
        }

        public bool HelpFetchCar()
        {
             return false;
        }

        public bool HelpFetchCar(Ticket ticket)
        {
            var isContainThisCar = ticketsList.Contains(ticket);
            if (isContainThisCar)
            {
                ticketsList.Remove(ticket);
            }

            return isContainThisCar;
        }
    }
}