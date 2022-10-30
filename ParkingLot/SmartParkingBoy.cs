using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        private string parkingBoyName;
        private List<Ticket> hadBeenParkedCarTicketList;

        public SmartParkingBoy(string parkingBoyName)
        {
            this.parkingBoyName = parkingBoyName;
            this.hadBeenParkedCarTicketList = new List<Ticket>();
        }

        public new List<Ticket> ParkingCar(List<Car> carList, List<ParkingLotClass> parkingLotList)
        {
            int maxCapacityForParkingLot = 3;
            foreach (Car car in carList)
            {
                ParkingLotClass chooseParkingLot = parkingLotList.OrderByDescending(eachParkingLot => eachParkingLot.ParkingLotCapacity).First();
                if (carList.IndexOf(car) < maxCapacityForParkingLot * parkingLotList.Count)
                {
                    Ticket hadBeenParkedCarTicket = new Ticket(car.OwnerName, chooseParkingLot.ParkingLotName, parkingBoyName);
                    hadBeenParkedCarTicket.HasBeenUsed = false;
                    hadBeenParkedCarTicketList.Add(hadBeenParkedCarTicket);
                    chooseParkingLot.ParkingLotCapacity--;
                }
                else
                {
                    throw new ArgumentException("Not enough position.");
                }
            }

            return hadBeenParkedCarTicketList;
        }
    }
}
