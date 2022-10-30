using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

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

        public List<Ticket> ParkingCar(List<Car> carList, ParkingLotClass parkingLot)
        {
            List<Ticket> ticketList = new List<Ticket>();
            foreach (Car car in carList)
            {
                ticketList.Add(new Ticket(car.OwnerName, parkingLot.ParkingLotName, parkingBoyName));
            }

            return ticketList;
        }
    }
}