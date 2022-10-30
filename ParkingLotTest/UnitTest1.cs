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
            var parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);

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
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            List<Car> cars = new List<Car>();

            cars.Add(new Car());
            cars.Add(new Car());

            parkingboy.Checkin(cars);

            Ticket ticket = cars[0].Myticket;

            Car car_get = parkingboy.Checkout(ticket);

            Assert.Equal(cars[0], car_get);
        }

        [Fact]
        public void Should_get_no_car_when_ticket_wrong_if_given_a_wrong_ticket()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            Ticket ticket = new Ticket();

            Car car_get = parkingboy.Checkout(ticket);

            Assert.NotEqual(car, car_get);
        }

        [Fact]
        public void Should_get_no_car_when_ticket_used_if_given_a_used_ticket()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            Ticket ticket = car.Myticket;

            var car_get = parkingboy.Checkout(ticket);

            car_get = parkingboy.Checkout(ticket);

            Assert.NotEqual(car, car_get);
        }

        [Fact]
        public void Should_get_no_ticket_when_no_capacity_if_given_a_car()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 2);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            List<Car> cars = new List<Car>();

            cars.Add(new Car());
            cars.Add(new Car());

            parkingboy.Checkin(cars);

            Car car = new Car();
            parkingboy.Checkin(car);

            Ticket ticket = car.Myticket;

            Assert.Null(ticket);
        }

        [Fact]
        public void Should_get_Unrecognized_parking_ticket_when_ticket_if_wrong()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            Ticket ticket = new Ticket();

            Car car_get = parkingboy.Checkout(ticket);

            Assert.Equal("Unrecognized parking ticket.", parkingboy.Personalizedmessage);
        }

        [Fact]
        public void Should_get_Please_provide_your_parking_ticket_when_ticket_if_no()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            parkingboy.Checkout();

            Assert.Equal("Please provide your parking ticket.", parkingboy.Personalizedmessage);
        }

        [Fact]
        public void Should_get_Not_enough_position_when_parkinglot_if_full()
        {
            Parkinglot parkinglot = new Parkinglot(name: "myp", capacity: 0);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot);
            Car car = new Car();

            parkingboy.Checkin(car);

            Assert.Equal("Not enough position.", parkingboy.Personalizedmessage);
        }

        [Fact]
        public void Should_park_to_the_next_only_if_previous_full_when_parkinglot_if_full_if_given_multiple_lots()
        {
            Parkinglot parkinglot1 = new Parkinglot(name: "myp", capacity: 2);
            Parkinglot parkinglot2 = new Parkinglot(name: "myp", capacity: 10);
            ParkingProperty parkingproperty = new ParkingProperty(name: "dude");
            var parkingboy = new ParkingBoy(parkingproperty: parkingproperty);
            parkingproperty.Addparkingboy(parkingboy);
            parkingproperty.Addparkinglot(parkinglot1);
            parkingproperty.Addparkinglot(parkinglot2);
            Car car1 = new Car();

            parkingboy.Checkin(car1);

            Car car2 = new Car();

            parkingboy.Checkin(car2);

            Car car3 = new Car();

            parkingboy.Checkin(car3);

            List<int> should = new List<int> { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Assert.Equal(should, parkinglot2.Parkingspace);
        }
    }
}
