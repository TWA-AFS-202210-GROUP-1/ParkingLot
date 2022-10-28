namespace ParkingLotTest
{
  using ParkingLot;
  using Xunit;

  public class ParkingBoyTest
  {
    [Fact]
    public void Should_return_ticket_when_park_given_a_car()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(parkingLot);
      var car = new Car();
      // when
      var ticket = parkingBoy.Park(car);
      // then
      Assert.NotNull(ticket);
    }
  }
}