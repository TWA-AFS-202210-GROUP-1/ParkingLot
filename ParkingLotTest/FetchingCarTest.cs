namespace ParkingLotTest
{
    using DeepEqual.Syntax;
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using Xunit;
    public class FetchingCarTest
    {
        [Fact]
        public void Should_return_car_object_When_fetching_car_Given_ticket()
        {
            //given
            Car car = new Car(ownerName: "Tom");
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            Ticket ticket = parkingBoy.ParkingCar(car, parkingLot);

            //when
            var fetchingResult = parkingBoy.FetchingCar(ticket);

            //then
            fetchingResult.ShouldDeepEqual(car);
        }

        [Theory]
        [InlineData("Wrong Person", "Lot1", "boy1")]
        [InlineData("Tom", "Wrong Lot", "boy1")]
        [InlineData("Tom", "Lot1", "Wrong Boy")]
        public void Should_throw_a_exception_When_fetching_car_Given_a_wrong_ticket(string carNameOfTest, string lotNameOfTest, string boyNameOfTest)
        {
            //given
            Car car = new Car(ownerName: "Tom");
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            parkingBoy.ParkingCar(car, parkingLot);
            Ticket ticket = new Ticket(carNameOfTest, lotNameOfTest, boyNameOfTest);

            //when
            //then
            var ex = Assert.Throws<ArgumentException>(() => parkingBoy.FetchingCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }

        [Fact]
        public void Should_throw_exception_When_fetching_car_Given_used_ticket()
        {
            //given
            Car car = new Car(ownerName: "Tom");
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            var ticket = parkingBoy.ParkingCar(car, parkingLot);
            parkingBoy.FetchingCar(ticket);

            //when
            //then
            var ex = Assert.Throws<ArgumentException>(() => parkingBoy.FetchingCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }
    }
}
