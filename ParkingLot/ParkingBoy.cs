using System.Collections.Generic;

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

    public List<Ticket> Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      foreach (var car in cars)
      {
        var operationStatus = parkingLot.AddCar(car);
        if (operationStatus == OperationStatus.ParkingSuccessful)
        {
          tickets.Add(new Ticket(car));
        }
      }

      return tickets;
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