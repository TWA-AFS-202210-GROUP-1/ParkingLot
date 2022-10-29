using System.Collections.Generic;

namespace ParkingLot
{
    using System;
    public class ParkingBoy
    {
        public ParkingBoy()
        {
        }

        public Ticket ParkCar(Car car)
        {
            var lotNo = 1;
            return new Ticket(car.LicensePlate, lotNo);
        }

        public string FetchCar(Ticket ticket)
        {
            var licensePlate = ticket.LicensePlate;
            return licensePlate;
        }
    }
}
