using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingBoy()
        {
        }

        public Ticket ParkingCar(Car car)
        {
            Ticket ticket = new Ticket(car.Name);
            return ticket;
        }

        public Car FetchingCar(Ticket ticket)
        {
            Car car = new Car(ticket.CarName);
            return car;
        }
    }
}
