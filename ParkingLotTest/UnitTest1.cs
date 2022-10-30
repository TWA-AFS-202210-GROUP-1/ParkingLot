namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System;
    using Xunit;
    using System.Linq;

    public class UnitTest1
    {
        [Fact]
        public void Should_get_ticket_when_park_at_parkinglot_if_given_a_car()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingBoy parkingboy = new ParkingBoy(myparkinglot: parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            Ticket ticket = car.Myticket;

            Car car_get = parkingboy.Checkout(ticket);

            Assert.Equal(car, car_get);
        }

        [Fact]
        public void Should_park_multiple_when_multiple_cars_if_given_multiple_cars()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingBoy parkingboy = new ParkingBoy(myparkinglot: parkinglot);
            List<Car> cars = new List<Car>();

            cars.Add(new Car());
            cars.Add(new Car());

            parkingboy.Checkin(cars);

            Ticket ticket = cars[0].Myticket;

            Car car_get = parkingboy.Checkout(ticket);

            Assert.Equal(cars[0], car_get);
        }
    }
}
