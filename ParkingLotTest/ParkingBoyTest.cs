using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;

namespace ParkingLotTest
{
    using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
    using ParkingLot;
    using System.Net.Sockets;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
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
            var parkResult = parkingBoy.ParkCar(car);
            // then
            Assert.NotNull(parkResult.subject);
        }

        [Fact]
        public void Should_return_a_car_when_parking_boy_fetch_a_car_given_a_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var car = new Car("ThisIsLicensePlate");
            var parkResult = parkingBoy.ParkCar(car);
            // when
            var fetchResult = parkingBoy.FetchCar(parkResult.subject);
            // then
            Assert.Equal(car, fetchResult.subject);
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
            var fetchedCars = parkingBoy.FetchManyCars(ticketList);
            // then
            Assert.Equal(carList, fetchedCars);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_wrong_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var ticket = new Ticket("InvalidLicensePlate", "Invalid");
            parkingBoy.ParkCar(new Car("LicensePlate"));
            // when
            var fetchResult = parkingBoy.FetchCar(ticket);
            // then
            Assert.Null(fetchResult.subject);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_null_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            parkingBoy.ParkCar(new Car("LicensePlate"));
            // when
            var fetchResult = parkingBoy.FetchCar(null);
            // then
            Assert.Null(fetchResult.subject);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_used_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var parkResult = parkingBoy.ParkCar(new Car("LicensePlate"));
            parkingBoy.FetchCar(parkResult.subject);
            // when
            var fetchResult = parkingBoy.FetchCar(parkResult.subject);
            // then
            Assert.Null(fetchResult.subject);
            Assert.True(parkResult.subject.Used);
        }

        [Fact]
        public void Should_return_null_when_parking_lot_is_full_given_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>();
            for (int num = 0; num < 10; num++)
            {
                carList.Add(new Car($"LicensePlate{num}"));
            }

            parkingBoy.ParkManyCars(carList);
            var extraCar = new Car("LicensePlateExtra");

            // when
            var parkResult = parkingBoy.ParkCar(extraCar);
            // then
            Assert.Null(parkResult.subject);
        }

        [Fact]
        public void Should_return_error_message_when_parking_boy_fetch_given_a_wrong_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>()
            {
                new Car("LicensePlate1"),
                new Car("LicensePlate2"),
            };
            parkingBoy.ParkManyCars(carList);
            var ticket = new Ticket("InvalidLicense", "lotId");
            // when
            var fetchResult = parkingBoy.FetchCar(ticket);
            // then
            Assert.Equal("Unrecognized parking ticket.", fetchResult.message);
        }

        [Fact]
        public void Should_return_error_message_when_parking_boy_fetch_given_null_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>()
            {
                new Car("LicensePlate1"),
                new Car("LicensePlate2"),
            };
            parkingBoy.ParkManyCars(carList);

            // when
            var fetchResult = parkingBoy.FetchCar(null);
            // then
            Assert.Equal("Please provide your parking ticket.", fetchResult.message);
        }

        [Fact]
        public void Should_return_error_message_when_parking_lot_is_full_given_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carList = new List<Car>();
            for (int num = 0; num < 10; num++)
            {
                carList.Add(new Car($"LicensePlate{num}"));
            }

            parkingBoy.ParkManyCars(carList);
            var extraCar = new Car("LicensePlateExtra");

            // when
            var fetchResult = parkingBoy.ParkCar(extraCar);
            // then
            Assert.Equal("Not enough position.", fetchResult.message);
        }
    }
}
