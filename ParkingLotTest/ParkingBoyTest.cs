using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ParkingLotTest
{
    using ParkingLot;
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
    }
}
