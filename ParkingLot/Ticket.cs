using System;

namespace ParkingLot
{
    public class Ticket
    {
        private string carNum;
        private string ticketNum;

        public Ticket()
        {
        }

        public Ticket(string carNum, TicketNumGenerator ticketNumGenerator)
        {
            this.CarNum = carNum;
            this.TicketNum = ticketNumGenerator.GenerateTicketNum();
        }

        public string CarNum { get => carNum; set => carNum = value; }
        public string TicketNum { get => ticketNum; set => ticketNum = value; }
    }
}