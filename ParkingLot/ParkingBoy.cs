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
            var lotID = "lotID";
            return new Ticket(car.LicensePlate, lotID);
        }

        public string FetchCar(Ticket ticket)
        {
            var licensePlate = ticket.LicensePlate;
            return licensePlate;
        }
    }
}
