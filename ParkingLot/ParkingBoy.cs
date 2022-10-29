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
      var parkingTicket = parkingLot.EmptySlots > 0 ? new Ticket(car) : null;
      parkingLot.AddCar(car);

      return parkingTicket;
    }

    public List<Ticket> Park(List<Car> cars)
    {
      var tickets = new List<Ticket>();
      foreach (var car in cars)
      {
        parkingLot.AddCar(car);
        tickets.Add(new Ticket(car));
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