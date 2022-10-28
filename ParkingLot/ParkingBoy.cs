using System;
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
      parkingLot.AddCar(car);

      return new Ticket(car);
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
      return ticket.Car;
    }
  }
}