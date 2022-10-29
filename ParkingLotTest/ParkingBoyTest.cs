namespace ParkingLotTest
{
  using ParkingLot;
  using System.Collections.Generic;
  using System.Linq;
  using Xunit;

  public class ParkingBoyTest
  {
    [Fact]
    public void Should_return_ticket_when_park_given_a_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      // when
      var ticket = parkingBoy.Park(new Car("Blue Sedan"));
      // then
      Assert.IsType<Ticket>(ticket);
    }

    [Fact]
    public void Should_return_same_car_when_fetch_car_given_a_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var car = new Car("Blue Sedan");
      var ticket = parkingBoy.Park(car);
      // when
      var fetchedCar = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal(car, fetchedCar);
    }

    [Fact]
    public void Should_return_tickets_when_park_multiple_cars_given_car_list()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var cars = new List<Car>
      {
        new Car("Blue Sedan"),
        new Car("White SUV"),
      };
      // when
      var tickets = parkingBoy.Park(cars);
      // then
      Assert.IsType<List<Ticket>>(tickets);
      Assert.NotEmpty(tickets);
    }

    [Fact]
    public void Should_return_right_car_when_fetch_car_given_corresponding_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var cars = new List<Car>
      {
        new Car("Blue Sedan"),
        new Car("White SUV"),
      };
      var tickets = parkingBoy.Park(cars);
      // when
      var fetchedCars = tickets.Select(ticket => parkingBoy.FetchCar(ticket)).ToList();
      // then
      Assert.Equal(cars, fetchedCars);
    }

    [Fact]
    public void Should_return_null_when_fetch_car_given_wrong_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var wrongTicket = new Ticket(new Car("Blue Sedan"));
      // when
      var fetchedCar = parkingBoy.FetchCar(wrongTicket);
      // then
      Assert.Null(fetchedCar);
    }

    [Fact]
    public void Should_return_null_when_fetch_car_given_no_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      // when
      var fetchedCar = parkingBoy.FetchCar(null);
      // then
      Assert.Null(fetchedCar);
    }

    [Fact]
    public void Should_return_null_when_fetch_car_given_used_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var ticket = parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.FetchCar(ticket);
      // when
      var anotherFetchedCar = parkingBoy.FetchCar(ticket);
      // then
      Assert.Null(anotherFetchedCar);
    }

    [Fact]
    public void Should_return_null_when_park_given_a_car_and_a_filled_parking_lot()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot(2));
      parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.Park(new Car("Black Jeep"));
      // when
      var ticket = parkingBoy.Park(new Car("White SUV"));
      // then
      Assert.Null(ticket);
    }

    [Fact]
    public void Should_return_ticket_when_park_given_a_car_and_available_parking_lot()
    {
      // given
      var parkingLot = new ParkingLot(2);
      var parkingBoy = new ParkingBoy(parkingLot);
      parkingBoy.Park(new Car("Blue Sedan"));
      var blackJeepTicket = parkingBoy.Park(new Car("Black Jeep"));
      parkingBoy.FetchCar(blackJeepTicket);
      // when
      var newTicket = parkingBoy.Park(new Car("White SUV"));
      // then
      Assert.IsType<Ticket>(newTicket);
      Assert.Equal(0, parkingLot.EmptySlots);
    }

    [Fact]
    public void Should_return_2_tickets_when_park_given_3_cars_and_2_empty_parking_lot_slots()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot(3));
      parkingBoy.Park(new Car("Blue Sedan"));
      var cars = new List<Car>
      {
        new Car("Black Jeep"),
        new Car("White SUV"),
        new Car("Red Mustang"),
      };
      // when
      var tickets = parkingBoy.Park(cars);
      // then
      Assert.Equal(2, tickets.Count);
    }

    [Fact]
    public void Should_return_null_when_park_given_a_parked_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var car = new Car("Blue Sedan");
      parkingBoy.Park(car);
      // when
      var ticket = parkingBoy.Park(car);
      // then
      Assert.Null(ticket);
    }

    [Fact]
    public void Should_return_null_when_park_given_a_null_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      Car car = null;
      // when
      var ticket = parkingBoy.Park(car);
      // then
      Assert.Null(ticket);
    }
  }
}