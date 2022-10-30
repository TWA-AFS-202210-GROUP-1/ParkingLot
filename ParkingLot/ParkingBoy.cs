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

        public Ticket ParkCar(string carNum, TicketNumGenerator ticketNumGenerator)
        {
            this.ticketNumGenerator = ticketNumGenerator;
            Ticket ticket = new Ticket(carNum, ticketNumGenerator);
            this.TicketsList.Add(ticket);
            return ticket;
        }
    }
}