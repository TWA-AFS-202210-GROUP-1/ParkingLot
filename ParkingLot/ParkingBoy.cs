using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLotSystem
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots;
        public ParkingBoy()
        {
            this.parkingLots = new List<ParkingLot>();
        }

        public ParkResponse<Ticket> HelpParkCar(Car car)
        {
            foreach (ParkingLot parkingLot in parkingLots)
            {
                if (parkingLot.IsAvailable())
                {
                    Ticket ticket = new Ticket(car.CarNum, parkingLot.LotId);
                    parkingLot.AddCar(car);
                    return new ParkResponse<Ticket>(ticket, "Enough position.");
                }
            }

            return new ParkResponse<Ticket>(null, "Not enough position.");
        }

        public List<ParkResponse<Ticket>> HelpParkCar(List<Car> carsList)
        {
           return carsList.Select(carsList => HelpParkCar(carsList)).ToList();
        }

        public FetchCarResponse<Car> HelpFetchCar()
        {
            return new FetchCarResponse<Car>(null, "Please provide your parking ticket.");
        }

        public FetchCarResponse<Car> HelpFetchCar(Ticket ticket)
        {
            ParkingLot targetParkingLot = parkingLots.Find(i => i.LotId == ticket.LotId);
            if (targetParkingLot != null)
            {
                Car targetCar = targetParkingLot.Cars.Find(i => i.CarNum == ticket.CarNum);
                if (targetCar != null)
                {
                    targetParkingLot.RemoveCar(targetCar);
                    return new FetchCarResponse<Car>(targetCar, "Fetch car successfully");
                }
            }

            return new FetchCarResponse<Car>(null, "Unrecognized parking ticket.");
        }

        public void AssignParkingLot(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }
    }
}