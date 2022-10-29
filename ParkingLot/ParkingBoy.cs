using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
  public class ParkingBoy
  {
    private readonly ParkingLot parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
      this.parkingLot = parkingLot;
    }

    public Response Park(Car car)
    {
      var parkingStatus = parkingLot.AddCar(car);
      var parkingTicket = parkingStatus == OperationStatus.ParkingSuccessful ? new Ticket(car) : null;

      return new Response(car, parkingTicket, parkingStatus);
    }

    public Response Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      OperationStatus parkingStatus = OperationStatus.ParkingSuccessful;
      foreach (var car in cars)
      {
        var operationStatus = parkingLot.AddCar(car);
        if (operationStatus == OperationStatus.ParkingSuccessful)
        {
          parkingStatus = operationStatus;
          tickets.Add(new Ticket(car));
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

      var parkedCars = cars.Take(tickets.Count).ToList();
      return new Response(parkedCars, tickets, parkingStatus);
    }

    public Response FetchCar(Ticket ticket)
    {
      var fetchedCar = ticket != null && parkingLot.HasCar(ticket.Car) ? ticket.Car : null;
      var fetchingStatus = parkingLot.RemoveCar(fetchedCar);
      var response = new Response(fetchedCar, ticket, fetchingStatus);

      return response;
    }
  }
}