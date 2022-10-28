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
      var ticket = parkingBoy.ParkCar(car);
      // then
      Assert.NotNull(ticket);
    }

    [Fact]
    public void Should_return_same_car_when_fetch_parked_car_given_a_ticket()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(parkingLot);
      var car = new Car();
      // when
      var ticket = parkingBoy.ParkCar(car);
      var fetchedCar = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal(car, fetchedCar);
    }
  }
}