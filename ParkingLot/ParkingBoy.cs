using System;

namespace ParkingLot
{
  public class ParkingBoy
  {
    private ParkingLot parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
      this.parkingLot = parkingLot;
    }

    public Ticket ParkCar(Car car)
    {
      parkingLot.AddCar(car);

      return new Ticket(car);
    }

    public Car FetchCar(Ticket ticket)
    {
      return ticket.Car;
    }
  }
}