namespace ParkingLot
{
    using System;
    using System.Linq;

    public class ParkingBoy
    {
        private Parkinglot myparkinglot;
        public ParkingBoy(Parkinglot myparkinglot)
        {
            this.myparkinglot = myparkinglot;
        }

        public Parkinglot Myparkinglot
        {
            get
            {
                return myparkinglot;
            }

            set
            {
               myparkinglot = value;
            }
        }

        public Ticket Checkin(Car car)
        {
            Ticket ticket = new Ticket(car: car, number: myparkinglot.Ticketnumber);
            myparkinglot.Ticketnumber++;
            myparkinglot.Currentcarnum++;
            myparkinglot.Parkingspace[0] = ticket.Number;
            return ticket;
        }

        public Car Checkout(Ticket ticket)
        {
            for (int i = 0; i < myparkinglot.Parkingspace.Count; i++)
            {
                if (ticket.Number == myparkinglot.Parkingspace[i])
                {
                    myparkinglot.Parkingspace[i] = 0;
                    ticket.Status = 0;
                    return ticket.Correspondingcar;
                }
            }

            return new Car();
        }
    }
}
