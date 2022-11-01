using System;

namespace ParkingLotSystem
{
    public class ParkResponse<T>
    {
        public ParkResponse(T ticket, string parkMsg)
        {
            this.ParkMsg = parkMsg;
            this.Ticket = ticket;
        }

        public string ParkMsg { get; set; }
        public T Ticket { get; set; }
    }
}