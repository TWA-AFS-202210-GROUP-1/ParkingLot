namespace ParkingLot
{
  public class Ticket
  {
    public Ticket(Car car, ParkingLot parkingLot)
    {
      Car = car;
      ParkingLot = parkingLot;
    }

    public Car Car { get; private set; }
    public ParkingLot ParkingLot { get; private set; }
  }
}