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
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      // when
      var response = parkingBoy.Park(new Car("Blue Sedan"));
      // then
      Assert.IsType<Ticket>(response.ShowTicket());
    }

    [Fact]
    public void Should_return_same_car_when_fetch_car_given_a_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var car = new Car("Blue Sedan");
      var parkingResponse = parkingBoy.Park(car);
      // when
      var fetchingResponse = parkingBoy.FetchCar(parkingResponse.ShowTicket());
      // then
      Assert.Equal(car, fetchingResponse.ShowCar());
    }

    [Fact]
    public void Should_return_tickets_when_park_multiple_cars_given_car_list()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var cars = new List<Car>
      {
        new Car("Blue Sedan"),
        new Car("White SUV"),
      };
      // when
      var tickets = parkingBoy.Park(cars).ShowTickets();
      // then
      Assert.IsType<List<Ticket>>(tickets);
      Assert.NotEmpty(tickets);
    }

    [Fact]
    public void Should_return_right_car_when_fetch_car_given_corresponding_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var cars = new List<Car>
      {
        new Car("Blue Sedan"),
        new Car("White SUV"),
      };
      var tickets = parkingBoy.Park(cars).ShowTickets();
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
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot });
      var wrongTicket = new Ticket(new Car("Blue Sedan"), parkingLot);
      // when
      var response = parkingBoy.FetchCar(wrongTicket);
      // then
      Assert.Null(response.ShowCar());
    }

    [Fact]
    public void Should_return_null_car_when_fetch_car_given_no_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      // when
      var response = parkingBoy.FetchCar(null);
      // then
      Assert.Null(response.ShowCar());
    }

    [Fact]
    public void Should_return_null_car_when_fetch_car_given_used_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var parkingResponse = parkingBoy.Park(new Car("Blue Sedan"));
      var ticket = parkingResponse.ShowTicket();
      parkingBoy.FetchCar(ticket);
      // when
      var fetchingResponse = parkingBoy.FetchCar(ticket);
      // then
      Assert.Null(fetchingResponse.ShowCar());
    }

    [Fact]
    public void Should_return_null_ticket_when_park_given_a_car_and_a_filled_parking_lot()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(2) });

      parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.Park(new Car("Black Jeep"));
      // when
      var response = parkingBoy.Park(new Car("White SUV"));
      // then
      Assert.Null(response.ShowTicket());
    }

    [Fact]
    public void Should_return_ticket_when_park_given_a_car_and_available_parking_lot()
    {
      // given
      var parkingLot = new ParkingLot(2);
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot });
      parkingBoy.Park(new Car("Blue Sedan"));
      var response = parkingBoy.Park(new Car("Black Jeep"));
      parkingBoy.FetchCar(response.ShowTicket());
      // when
      var newResponse = parkingBoy.Park(new Car("White SUV"));
      // then
      Assert.IsType<Ticket>(newResponse.ShowTicket());
      Assert.Equal(0, parkingLot.EmptySlots);
    }

    [Fact]
    public void Should_return_2_tickets_when_park_given_3_cars_and_2_empty_parking_slots()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(3) });
      parkingBoy.Park(new Car("Blue Sedan"));
      var cars = new List<Car>
      {
        new Car("Black Jeep"),
        new Car("White SUV"),
        new Car("Red Mustang"),
      };
      // when
      var tickets = parkingBoy.Park(cars).ShowTickets();
      // then
      Assert.Equal(2, tickets.Count);
    }

    [Fact]
    public void Should_return_right_cars_when_fetch_given_corresponding_tickets_after_partially_successful_parking()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(3) });
      parkingBoy.Park(new Car("Blue Sedan"));
      var cars = new List<Car>
      {
        new Car("Black Jeep"),
        new Car("White SUV"),
        new Car("Red Mustang"),
      };
      var response = parkingBoy.Park(cars);
      var tickets = response.ShowTickets();
      var parkedCars = response.ShowCars();
      // when
      var responses = tickets.Select(ticket => parkingBoy.FetchCar(ticket)).ToList();
      var fetchedCars = responses.Select(response => response.ShowCar()).ToList();
      // then
      Assert.Equal(cars.Take(2).ToList(), parkedCars);
      Assert.Equal(parkedCars, fetchedCars);
    }

    [Fact]
    public void Should_return_null_ticket_when_park_given_a_parked_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var car = new Car("Blue Sedan");
      parkingBoy.Park(car);
      // when
      var response = parkingBoy.Park(car);
      // then
      Assert.Null(response.ShowTicket());
    }

    [Fact]
    public void Should_return_null_ticket_when_park_given_a_null_car()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      Car car = null;
      // when
      var response = parkingBoy.Park(car);
      // then
      Assert.Null(response.ShowTicket());
    }

    [Fact]
    public void Should_return_wrong_ticket_message_when_fetch_car_given_wrong_ticket()
    {
      // given
      var parkingLot = new ParkingLot();
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot });
      var wrongTicket = new Ticket(new Car("Blue Sedan"), parkingLot);
      // when
      var response = parkingBoy.FetchCar(wrongTicket);
      // then
      Assert.Equal("Unrecognized parking ticket.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_wrong_ticket_message_when_fetch_car_given_used_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      var parkingResponse = parkingBoy.Park(new Car("Blue Sedan"));
      var ticket = parkingResponse.ShowTicket();
      parkingBoy.FetchCar(ticket);
      // when
      var fetchingResponse = parkingBoy.FetchCar(ticket);
      // then
      Assert.Equal("Unrecognized parking ticket.", fetchingResponse.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_no_ticket_message_when_fetch_car_given_no_ticket()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot() });
      // when
      var response = parkingBoy.FetchCar(null);
      // then
      Assert.Equal("Please provide your parking ticket.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_no_position_message_when_park_given_car_and_filled_parking_lot()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(2) });
      parkingBoy.Park(new Car("Blue Sedan"));
      parkingBoy.Park(new Car("Black Jeep"));
      // when
      var response = parkingBoy.Park(new Car("White SUV"));
      // then
      Assert.Equal("Not enough position.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_2_tickets_and_no_position_message_when_park_given_3_cars_and_2_empty_parking_slots()
    {
      // given
      var parkingBoy = new ParkingBoy(new List<ParkingLot> { new ParkingLot(3) });
      parkingBoy.Park(new Car("Blue Sedan"));
      var cars = new List<Car>
      {
        new Car("Black Jeep"),
        new Car("White SUV"),
        new Car("Red Mustang"),
      };
      // when
      var response = parkingBoy.Park(cars);
      // then
      Assert.Equal(2, response.ShowTickets().Count);
      Assert.Equal("Not enough position.", response.ShowErrorMessage());
    }

    [Fact]
    public void Should_return_tickets_of_same_parking_lot_when_park_given_2_cars_and_2_default_parking_lots()
    {
      // given
      var parkingLots = new List<ParkingLot>
      {
        new ParkingLot(),
        new ParkingLot(),
      };
      var parkingBoy = new ParkingBoy(parkingLots);
      // when
      var blueSedanTicket = parkingBoy.Park(new Car("Blue Sedan")).ShowTicket();
      var blackJeepTicket = parkingBoy.Park(new Car("Black Jeep")).ShowTicket();
      // then
      Assert.Equal(parkingLots[0].Id, blueSedanTicket.ParkingLot.Id);
      Assert.Equal(parkingLots[0].Id, blackJeepTicket.ParkingLot.Id);
    }
  }
}