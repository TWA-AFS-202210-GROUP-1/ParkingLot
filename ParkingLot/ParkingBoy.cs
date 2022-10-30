using System.Collections.Generic;
using System.Linq;
using static ParkingLot.ChooseParkingLotService;

namespace ParkingLot
{
  public class ParkingBoy
  {
    private readonly List<ParkingLot> parkingLots;
    private readonly ChooseParkingLotDelegate chooseParkingLot;

    public ParkingBoy(List<ParkingLot> parkingLots, ChooseParkingLotDelegate chooseParkingLot)
    {
      this.parkingLots = parkingLots;
      this.chooseParkingLot = chooseParkingLot;
    }

    public virtual Response Park(Car car)
    {
      var parkingLot = chooseParkingLot(parkingLots);
      var parkingStatus = OperationStatus.NoVacancy;
      Ticket parkingTicket = null;

      if (parkingLot != null)
      {
        parkingStatus = parkingLot.AddCar(car);
        parkingTicket = parkingStatus == OperationStatus.ParkingSuccessful ? new Ticket(car, parkingLot) : null;
      }

      return new Response(car, parkingTicket, parkingStatus);
    }

    public virtual Response Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      OperationStatus parkingStatus = OperationStatus.ParkingFailed;

      foreach (var car in cars)
      {
        var parkingLot = chooseParkingLot(parkingLots);
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

    public Response FetchCar(Ticket ticket)
    {
      var response = new Response(null, ticket, OperationStatus.RemovingFailed);

      foreach (var parkingLot in parkingLots)
      {
        var fetchedCar = ticket != null && parkingLot.HasCar(ticket.Car) ? ticket.Car : null;
        var fetchingStatus = parkingLot.RemoveCar(fetchedCar);
        response = new Response(fetchedCar, ticket, fetchingStatus);
        if (fetchedCar != null)
        {
          break;
        }
      }

      return response;
    }
  }
}