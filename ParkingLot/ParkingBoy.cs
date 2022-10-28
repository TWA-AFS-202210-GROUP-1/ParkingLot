namespace ParkingLot
{
  public class ParkingBoy
  {
    private ParkingLot parkingLot;

    public ParkingBoy(ParkingLot parkingLot)
    {
      this.parkingLot = parkingLot;
    }

    public Ticket Park(Car car)
    {
      return new Ticket(car);
    }
  }
}