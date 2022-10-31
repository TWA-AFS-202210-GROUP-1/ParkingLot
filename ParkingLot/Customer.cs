using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        public Customer(string name, Car car)
        {
            CustomerName = name;
            Car = car;
        }

        public Ticket MyTicket { get; set; }
        public string CustomerName { get; }

        public Car Car { get; set; }

        public Ticket ParkCar(ParkingBoy parkingBoy)
        {
            MyTicket = parkingBoy.ParkingCar(Car);
            return MyTicket;
        }

        public Car FetchCar(ParkingBoy parkingBoy)
        {
            Car mycar = parkingBoy.FetchingCar(MyTicket);
            return mycar;
        }
    }
}
