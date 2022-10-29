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
            var fetchResult = parkingBoy.FetchCar(ticket);
            // then
            Assert.Equal("aaa", fetchResult.message);
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
            Assert.Null(fetchResult.car);
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
            Assert.Null(fetchResult);
        }

        [Fact]
        public void Should_return_null_when_parking_boy_fetch_given_a_used_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var ticket = parkingBoy.ParkCar(new Car("LicensePlate"));
            parkingBoy.FetchCar(ticket);
            // when
            var fetchResult = parkingBoy.FetchCar(ticket);
            // then
            Assert.Null(fetchResult);
            Assert.True(ticket.Used);
        }

        [Fact]
        public void Should_return_null_when_parking_lot_is_full_given_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var carLot = new CarLot("lotId");
            var carList = new List<Car>();
            for (int num = 0; num < 10; num++)
            {
                carList.Add(new Car($"LicensePlate{num}"));
            }

            parkingBoy.ParkManyCars(carList);
            var extraCar = new Car("LicensePlateExtra");

            // when
            var ticket = parkingBoy.ParkCar(extraCar);
            // then
            Assert.Null(ticket);
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
    }
}
