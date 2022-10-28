using System.Collections.Generic;
using ParkingLotService;
using ParkingLotService.Const;
using Xunit;

namespace ParkingLotServiceTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_give_a_ticket_when_parking_boy_parking_given_a_car()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingBoy.AssignLot(parkingLot);
            //when

            var response = parkingBoy.ParkCar(car);

            //then
            Assert.NotNull(response);
        }

        [Fact]
        public void Should_give_a_car_when_parking_boy_fetch_car_given_a_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingBoy.AssignLot(parkingLot);

            var ticket = parkingBoy.ParkCar(car);
            //when

            var response = parkingBoy.FetchCar(ticket.Content);

            //then
            Assert.NotNull(response.Content);
            Assert.Equal("License Number", response.Content.LicenseNumber);
        }

        [Fact]
        public void Should_give_several_tickets_when_parking_boy_parking_given_several_car()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var cars = new List<Car>()
            {
                new Car("License Number 01"),
                new Car("License Number 02"),
            };

            //when
            var responses = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(2, responses.Count);
            Assert.Equal("License Number 01", responses[0].Content.Car.LicenseNumber);
            Assert.Equal("License Number 02", responses[1].Content.Car.LicenseNumber);
        }

        [Fact]
        public void Should_give_correspond_car_when_parking_boy_fetch_cars_given_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var cars = new List<Car>()
            {
                new Car("License Number 01"),
                new Car("License Number 02"),
            };

            var ticketsResponse = parkingBoy.ParkCars(cars);
            //when

            var response01 = parkingBoy.FetchCar(ticketsResponse[0].Content);
            var response02 = parkingBoy.FetchCar(ticketsResponse[1].Content);

            //then
            Assert.Equal("License Number 01", response01.Content.LicenseNumber);
            Assert.Equal("License Number 02", response02.Content.LicenseNumber);
        }

        [Fact]
        public void Should_give_null_car_and_wrong_ticker_message_when_parking_boy_fetch_cars_given_used_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var car = new Car("License NUmber");
            var ticket = parkingBoy.ParkCar(car);
            parkingBoy.FetchCar(ticket.Content);

            //when
            var response = parkingBoy.FetchCar(ticket.Content);

            //then
            Assert.Null(response.Content);
            Assert.Equal(ParkingBoyConst.WrongTicketMessage, response.Message);
        }

        [Fact]
        public void Should_give_null_car_with_wrong_ticket_message_when_parking_boy_fetch_cars_given_wrong_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var car = new Car("License NUmber");
            parkingBoy.ParkCar(car);

            var ticket = new Ticket(parkingBoy, car, parkingLot);

            //when
            var response = parkingBoy.FetchCar(ticket);

            //then
            Assert.Null(response.Content);
            Assert.Equal(ParkingBoyConst.WrongTicketMessage, response.Message);
        }

        [Fact]
        public void Should_give_null_car_with_null_ticket_message_when_parking_boy_fetch_cars_given_null_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var car = new Car("License NUmber");
            parkingBoy.ParkCar(car);

            //when
            var response = parkingBoy.FetchCar(null);

            //then
            Assert.Null(response.Content);
            Assert.Equal(ParkingBoyConst.NullTicketMessage, response.Message);
        }

        [Fact]
        public void Should_give_null_ticket_and_no_position_message_when_parking_boy_add_car_given_full_lot()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var car = new Car("License NUmber");
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.ParkCar(car);
            }

            //when
            var response = parkingBoy.ParkCar(car);

            //then
            Assert.Null(response.Content);
            Assert.Equal(ParkingBoyConst.NoPositionMessage, response.Message);
        }

        [Fact]
        public void Should_add_only_to_the_first_lot_when_add_car_given_two_lot_and_the_first_lot_is_not_full()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            var parkingLot02 = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var car = new Car("License NUmber");
            for (int i = 0; i < 5; i++)
            {
                parkingBoy.ParkCar(car);
            }

            //when
            var response = parkingBoy.ParkCar(car);

            //then
            Assert.NotNull(response.Content);
            Assert.Equal(6, parkingLot01.CarNumber);
            Assert.Equal(0, parkingLot02.CarNumber);
        }

        [Fact]
        public void Should_add_to_both_when_add_cars_given_two_lot_and_the_first_lot_is_full()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            var parkingLot02 = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var cars = new List<Car>()
            {
                new Car("License Number 01"),
                new Car("License Number 02"),
                new Car("License Number 03"),
            };
            for (int i = 0; i < 3; i++)
            {
                parkingBoy.ParkCars(cars);
            }

            //when
            var response = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(3, response.Count);
            Assert.Equal(10, parkingLot01.CarNumber);
            Assert.Equal(2, parkingLot02.CarNumber);
        }

        [Fact]
        public void Should_give_null_ticket_and_no_position_message_when_parking_boy_add_car_given_all_lot_full()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            var parkingLot02 = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var car = new Car("License Number 01");

            for (int i = 0; i < 20; i++)
            {
                parkingBoy.ParkCar(car);
            }

            //when
            var response = parkingBoy.ParkCar(car);

            //then
            Assert.Null(response.Content);
            Assert.Equal(ParkingBoyConst.NoPositionMessage, response.Message);
        }
    }
}
