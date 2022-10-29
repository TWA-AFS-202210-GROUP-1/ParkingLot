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

    public Ticket Park(Car car)
    {
      var operationStatus = parkingLot.AddCar(car);
      var parkingTicket = operationStatus == OperationStatus.Successful ? new Ticket(car) : null;

      return parkingTicket;
    }

    public List<Ticket> Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      foreach (var car in cars)
      {
        var operationStatus = parkingLot.AddCar(car);
        if (operationStatus == OperationStatus.Successful)
        {
          tickets.Add(new Ticket(car));
        }
      }

      return tickets;
    }

    public Car FetchCar(Ticket ticket)
    {
      var fetchedCar = ticket != null && parkingLot.HasCar(ticket.Car) ? ticket.Car : null;
      parkingLot.RemoveCar(fetchedCar);

      return fetchedCar;
    }
  }
}