namespace ParkingLot
{
    using System;
    public class Car
    {
        private Ticket myticket;
        private int parkingstatus;

        public Ticket Myticket
        {
            get
            {
                return myticket;
            }

            set
            {
                myticket = value;
            }
        }

        public int Parkingstatus
        {
            get
            {
                return parkingstatus;
            }

            set
            {
                parkingstatus = value;
            }
        }

        public void Parking(Ticket ticket, int parkingstatus)
        {
            this.myticket = ticket;
            this.parkingstatus = parkingstatus;
        }
    }
}
