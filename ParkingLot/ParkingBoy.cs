using System;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private string parkingBoyName;

        public ParkingBoy(string parkingBoyName)
        {
            this.parkingBoyName = parkingBoyName;
        }

        public Ticket ParkingCar(Car car, ParkingLotClass parkingLot)
        {
            return new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName);
        }
    }
}