using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
  public class ParkingBoy
  {
    private readonly List<ParkingLot> parkingLots;

    public ParkingBoy(List<ParkingLot> parkingLots)
    {
      this.parkingLots = parkingLots;
    }

    public Response Park(Car car)
    {
      var parkingStatus = OperationStatus.NoVacancy;
      Ticket parkingTicket = null;
      foreach (var parkingLot in parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0))
      {
        parkingStatus = parkingLot.AddCar(car);
        parkingTicket = parkingStatus == OperationStatus.ParkingSuccessful ? new Ticket(car, parkingLot) : null;
        break;
      }

      return new Response(car, parkingTicket, parkingStatus);
    }

    public Response Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      OperationStatus parkingStatus = OperationStatus.ParkingSuccessful;
      foreach (var parkingLot in parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0))
      {
        foreach (var car in cars)
        {
          var operationStatus = parkingLot.AddCar(car);
          if (operationStatus == OperationStatus.ParkingSuccessful)
          {
            parkingStatus = operationStatus;
            tickets.Add(new Ticket(car, parkingLot));
          }
          else if (operationStatus == OperationStatus.NoVacancy)
          {
            parkingStatus = operationStatus;
            break;
          }
          else
          {
            parkingStatus = OperationStatus.ParkingFailed;
            break;
          }
        }

        break;
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
      }

      return response;
    }
  }
}