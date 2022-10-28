using System.Linq;

namespace ParkingLotTest
{
  using ParkingLot;
  using System.Collections.Generic;
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

    [Fact]
    public void Should_return_same_car_when_fetch_car_given_a_ticket()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(parkingLot);
      var car = new Car();
      // when
      var ticket = parkingBoy.Park(car);
      var fetchedCar = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal(car, fetchedCar);
    }

    [Fact]
    public void Should_return_tickets_when_park_multiple_cars_given_car_list()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(parkingLot);
      var cars = new List<Car>
      {
        new Car(),
        new Car(),
      };
      // when
      var tickets = parkingBoy.Park(cars);
      // then
      Assert.NotEmpty(tickets);
    }

    [Fact]
    public void Should_return_right_car_when_fetch_car_given_corresponding_ticket()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(parkingLot);
      var cars = new List<Car>
      {
        new Car(),
        new Car(),
      };
      // when
      var tickets = parkingBoy.Park(cars);
      var fetchedCars = tickets.Select(ticket => parkingBoy.FetchCar(ticket)).ToList();
      // then
      Assert.Equal(cars, fetchedCars);
    }
  }
}