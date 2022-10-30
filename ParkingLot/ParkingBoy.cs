namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingBoy
    {
        private ParkingProperty parkingproperty;
        private List<string> messages;
        private string personalizedmessage;
        private bool taskdone;

        public ParkingBoy(ParkingProperty parkingproperty)
        {
            this.parkingproperty = parkingproperty;
            this.taskdone = false;
            this.messages = new List<string>(new string[] { "Unrecognized parking ticket.", "Please provide your parking ticket.", "Not enough position.", "All good Dude." });
        }

        public ParkingProperty Parkingproperty
        {
            get
            {
                return parkingproperty;
            }

            set
            {
               parkingproperty = value;
            }
        }

        public string Personalizedmessage
        {
            get
            {
                return personalizedmessage;
            }
        }

        public void Checkin(Car car)
        {
            Ticket ticket = new Ticket(car: car, number: parkingproperty.Ticketnumber);
            foreach (Parkinglot parkinglot in this.parkingproperty.Parkinglots)
            {
                if (taskdone is false)
                {
                    if (parkinglot.Currentcarnum < parkinglot.Capacity)
                    {
                        parkingproperty.Ticketnumber++;
                        parkingproperty.Currentcarnum++;
                        parkinglot.Currentcarnum++;
                        for (int i = 0; i < parkinglot.Parkingspace.Count; i++)
                        {
                            if (parkinglot.Parkingspace[i] == 0)
                            {
                                parkinglot.Parkingspace[i] = ticket.Number;
                                car.Parking(ticket, 1);
                                this.personalizedmessage = this.messages[3];
                                taskdone = true;
                                break;
                            }
                        }
                    }
                }
            }

            taskdone = false;
            ticket.Status = -1;
            this.personalizedmessage = this.messages[2];
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
            foreach (Parkinglot parkinglot in this.parkingproperty.Parkinglots)
            {
                for (int i = 0; i < parkinglot.Parkingspace.Count; i++)
                {
                    if (ticket.Number == parkinglot.Parkingspace[i])
                    {
                        parkinglot.Parkingspace[i] = 0;
                        parkinglot.Currentcarnum--;
                        parkingproperty.Currentcarnum--;
                        Car car = ticket.Correspondingcar;
                        car.Parkingstatus = 0;
                        ticket.Status = 0;
                        this.personalizedmessage = this.messages[3];
                        return car;
                    }
                }
            }

            this.personalizedmessage = this.messages[0];
            return new Car();
        }

        public void Checkout()
        {
            this.personalizedmessage = this.messages[1];
        }
    }
}
