using System;

namespace ParkingLotSystem
{
    public class TicketNumGenerator
    {
        public TicketNumGenerator()
        {
        }

        public virtual string GenerateTicketNum()
        {
            string ticketNum = Guid.NewGuid().ToString();
            return ticketNum;
        }
    }
}