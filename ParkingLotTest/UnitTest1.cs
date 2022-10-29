namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_get_ticket_when_park_at_parkinglot_if_given_a_car()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingBoy parkingboy = new ParkingBoy(myparkinglot: parkinglot);
            Car car = new Car();

            Ticket ticket = parkingboy.Checkin(car);

            Car car_get = parkingboy.Checkout(ticket);

            Assert.Equal(car, car_get);
        }
    }
}
