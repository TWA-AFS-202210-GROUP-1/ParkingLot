using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
  public class SmartParkingBoy : ParkingBoy
  {
    private readonly List<ParkingLot> parkingLots;
    private ParkingLot chosenParkingLot;

    public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
    {
      this.parkingLots = parkingLots;
      chosenParkingLot = parkingLots.First();
    }

    public override Response Park(Car car)
    {
      chosenParkingLot = ChooseParkingLot(parkingLots);
      var parkingStatus = OperationStatus.NoVacancy;
      Ticket parkingTicket = null;
      if (chosenParkingLot != null)
      {
        parkingStatus = chosenParkingLot.AddCar(car);
        parkingTicket = parkingStatus == OperationStatus.ParkingSuccessful
                      ? new Ticket(car, chosenParkingLot)
                      : null;
      }

      return new Response(car, parkingTicket, parkingStatus);
    }

    public override Response Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      OperationStatus parkingStatus = OperationStatus.ParkingFailed;
      foreach (var car in cars)
      {
        var parkingLot = ChooseParkingLot(parkingLots);
        if (parkingLot != null)
        {
          parkingStatus = parkingLot.AddCar(car);
        }
        else
        {
          parkingStatus = OperationStatus.NoVacancy;
          break;
        }

        if (parkingStatus == OperationStatus.ParkingSuccessful)
        {
          tickets.Add(new Ticket(car, parkingLot));
        }
      }

      var parkedCars = cars.Take(tickets.Count).ToList();
      return new Response(parkedCars, tickets, parkingStatus);
    }

    private static ParkingLot ChooseParkingLot(List<ParkingLot> parkingLots)
    {
      var chosenParkingLot = parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();

      return chosenParkingLot.Any()
           ? chosenParkingLot.OrderByDescending(parkingLot => parkingLot.EmptySlots).First()
           : null;
    }
  }
}
