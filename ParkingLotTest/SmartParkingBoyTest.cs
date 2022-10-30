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

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_return_a_ticket_when_smart_parking_boy_park_car_given_a_car()
        {
            // given
            var smartParkingBoy = new SmartParkingBoy();
            var carlot = new CarLot("first parking lot");
            carlot.CarList = new List<Car>() { new Car("a") };
            smartParkingBoy.ManageParkingLots(carlot);
            smartParkingBoy.ManageParkingLots(new CarLot("second parking lot"));
            var car = new Car("ThisIsLicensePlate");
            // when
            var parkResult = smartParkingBoy.ParkCar(car);
            // then
            Assert.Equal("second parking lot", parkResult.subject.lotId);
        }

        [Fact]
        public void Should_return_tickets_when_smart_parking_boy_park_cars_given_cars()
        {
            // given
            var smartParkingBoy = new SmartParkingBoy();
            var carLot1 = new CarLot("first parking lot");
            carLot1.capacity = 5;
            carLot1.CarList = new List<Car>()
            {
                new Car("LicensePlate1"),
            };
            smartParkingBoy.ManageParkingLots(carLot1);

            var carLot2 = new CarLot("second parking lot");
            carLot2.capacity = 7;
            carLot2.CarList = new List<Car>()
            {
                new Car("LicensePlate3"),
                new Car("LicensePlate4"),
            };
            smartParkingBoy.ManageParkingLots(carLot2);

            var carList = new List<Car>()
            {
                new Car("LicensePlate5"),
                new Car("LicensePlate6"),
                new Car("LicensePlate7"),
            };

            // when
            var ticketList = smartParkingBoy.ParkManyCars(carList);

            // then
            Assert.Equal("second parking lot", ticketList[0].lotId);
            Assert.Equal("second parking lot", ticketList[1].lotId);
            Assert.Equal("first parking lot", ticketList[2].lotId);
        }
    }
}
