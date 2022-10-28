namespace ParkingLot
{
  public class Ticket
  {
    public Ticket(Car car)
    {
      Car = car;
    }

    public Car Car { get; private set; }
  }
}