namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
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

        public void Checkin(Car car)
        {
            if (myparkinglot.Currentcarnum < myparkinglot.Capacity)
            {
                Ticket ticket = new Ticket(car: car, number: myparkinglot.Ticketnumber);
                myparkinglot.Ticketnumber++;
                myparkinglot.Currentcarnum++;
                for (int i = 0; i < myparkinglot.Parkingspace.Count; i++)
                {
                    if (myparkinglot.Parkingspace[i] == 0)
                    {
                        myparkinglot.Parkingspace[i] = ticket.Number;
                        car.Parking(ticket, 1);
                        break;
                    }
                }
            }
            else
            {
                Ticket ticket = new Ticket(car: car, number: myparkinglot.Ticketnumber);
                ticket.Status = -1;
            }
        }

        public void Checkin(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Checkin(car);
            }
        }

        public Car Checkout(Ticket ticket)
        {
            for (int i = 0; i < myparkinglot.Parkingspace.Count; i++)
            {
                if (ticket.Number == myparkinglot.Parkingspace[i])
                {
                    myparkinglot.Parkingspace[i] = 0;
                    myparkinglot.Currentcarnum--;
                    Car car = ticket.Correspondingcar;
                    car.Parkingstatus = 0;
                    ticket.Status = 0;
                    return car;
                }
            }

            return new Car();
        }
    }
}
