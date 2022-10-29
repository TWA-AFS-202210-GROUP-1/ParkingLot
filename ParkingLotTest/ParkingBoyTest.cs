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
      var response = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal(car, response.ShowCar());
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
      var responses = tickets.Select(ticket => parkingBoy.FetchCar(ticket)).ToList();
      var fetchedCars = responses.Select(response => response.ShowCar()).ToList();
      // then
      Assert.Equal(cars, fetchedCars);
    }

    [Fact]
    public void Should_return_null_car_when_fetch_car_given_wrong_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var wrongTicket = new Ticket(new Car("Blue Sedan"));
      // when
      var response = parkingBoy.FetchCar(wrongTicket);
      // then
      Assert.Null(response.ShowCar());
    }

    [Fact]
    public void Should_return_null_car_when_fetch_car_given_no_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      // when
      var response = parkingBoy.FetchCar(null);
      // then
      Assert.Null(response.ShowCar());
    }

    [Fact]
    public void Should_return_null_car_when_fetch_car_given_used_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var ticket = parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.FetchCar(ticket);
      // when
      var response = parkingBoy.FetchCar(ticket);
      // then
      Assert.Null(response.ShowCar());
    }

    [Fact]
    public void Should_return_null_ticket_when_park_given_a_car_and_a_filled_parking_lot()
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
    public void Should_return_null_ticket_when_park_given_a_parked_car()
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
    public void Should_return_null_ticket_when_park_given_a_null_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      Car car = null;
      // when
      var ticket = parkingBoy.Park(car);
      // then
      Assert.Null(ticket);
    }

    [Fact]
    public void Should_return_wrong_ticket_message_when_fetch_car_given_wrong_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var wrongTicket = new Ticket(new Car("Blue Sedan"));
      // when
      var response = parkingBoy.FetchCar(wrongTicket);
      // then
      Assert.Equal("Unrecognized parking ticket.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_wrong_ticket_message_when_fetch_car_given_used_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      var ticket = parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.FetchCar(ticket);
      // when
      var response = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal("Unrecognized parking ticket.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_no_ticket_message_when_fetch_car_given_no_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new ParkingLot());
      // when
      var response = parkingBoy.FetchCar(null);
      // then
      Assert.Equal("Please provide your parking ticket.", response.ShowErrorMessage());
    }
  }
}