using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParkingLotTest
{
    using ParkingLot;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_parking_boy_park_a_car_given_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var car = new Car("ThisIsLicensePlate");
            // when
            var ticket = parkingBoy.ParkCar(car);
            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_a_car_when_parking_boy_fetch_a_car_given_a_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var car = new Car("ThisIsLicensePlate");
            var ticket = parkingBoy.ParkCar(car);
            // when
            var licensePlate = parkingBoy.FetchCar(ticket);
            // then
            Assert.Equal("ThisIsLicensePlate", licensePlate);
        }

        [Fact]
        public void Should_return_tickets_when_parking_boy_park_cars_given_cars()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>()
            {
                new Car("LicensePlate1"),
                new Car("LicensePlate2"),
            };
            // when
            var ticketList = parkingBoy.ParkManyCars(carList);
            // then
            Assert.Equal("LicensePlate1", ticketList[0].LicensePlate);
            Assert.Equal("LicensePlate2", ticketList[1].LicensePlate);
            Assert.Equal(2, ticketList.Count);
        }

        [Fact]
        public void Should_return_cars_when_parking_boy_fetch_cars_given_a_tickets()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>()
            {
                new Car("LicensePlate1"),
                new Car("LicensePlate2"),
            };
            var ticketList = parkingBoy.ParkManyCars(carList);
            // when
            var licensePlateList = parkingBoy.FetchManyCars(ticketList);
            // then
            Assert.Equal("LicensePlate1", licensePlateList[0]);
            Assert.Equal("LicensePlate2", licensePlateList[1]);
            Assert.Equal(2, licensePlateList.Count);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_wrong_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var ticket = new Ticket("InvalidLicensePlate", "Invalid");
            parkingBoy.ParkCar(new Car("LicensePlate"));
            // when
            var licensePlate = parkingBoy.FetchCar(ticket);
            // then
            Assert.Null(licensePlate);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_null_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            parkingBoy.ParkCar(new Car("LicensePlate"));
            // when
            var licensePlate = parkingBoy.FetchCar();
            // then
            Assert.Null(licensePlate);
        }
    }
}
