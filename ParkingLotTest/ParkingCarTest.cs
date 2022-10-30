namespace ParkingLotTest
{
    using DeepEqual.Syntax;
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using Xunit;

    public class ParkingCarTest
    {
        [Fact]
        public void Should_return_ticket_object_When_parking_car_Given_car_and_parking_lot()
        {
            //given
            Car car = new Car(ownerName: "Tom");
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            var exceptedResult = new Ticket(carId: "Tom", parkingLotId: "Lot1", parkingBoyId: "boy1");
            exceptedResult.HasBeenUsed = false;

            //when
            var parkingResult = parkingBoy.ParkingCar(car, parkingLot);

            //then
            parkingResult.ShouldDeepEqual(exceptedResult);
        }

        [Fact]
        public void Should_return_multi_ticket_object_When_parking_car_Given_multi_car_and_parking_lot()
        {
            //given
            List<Car> carlist = new List<Car>()
            {
                new Car(ownerName: "Tom"),
                new Car(ownerName: "Jim"),
                new Car(ownerName: "Alice"),
            };
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            Ticket ticketForTom = new Ticket(carId: "Tom", parkingLotId: "Lot1", parkingBoyId: "boy1");
            ticketForTom.HasBeenUsed = false;
            Ticket ticketForJim = new Ticket(carId: "Jim", parkingLotId: "Lot1", parkingBoyId: "boy1");
            ticketForJim.HasBeenUsed = false;
            Ticket ticketForAlice = new Ticket(carId: "Alice", parkingLotId: "Lot1", parkingBoyId: "boy1");
            ticketForAlice.HasBeenUsed = false;
            var exceptedResult = new List<Ticket>()
            {
                ticketForTom,
                ticketForJim,
                ticketForAlice,
            };

            //when
            var parkingResult = parkingBoy.ParkingCar(carlist, parkingLot);

            //then
            parkingResult.ShouldDeepEqual(exceptedResult);
        }

        [Fact]
        public void Should_throw_exception_When_parking_car_Given_car_and_undercapacity_parking_lot()
        {
            //given
            List<Car> carlist = new List<Car>()
            {
                new Car(ownerName: "Tom"),
                new Car(ownerName: "Jim"),
                new Car(ownerName: "Alice"),
            };
            ParkingLotClass parkingLot = new ParkingLotClass(parkingLotName: "Lot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingBoyName: "boy1");
            parkingBoy.ParkingCar(carlist, parkingLot);
            Car extraCar = new Car(ownerName: "extra person");

            //when
            //then
            var ex = Assert.Throws<ArgumentException>(() => parkingBoy.ParkingCar(extraCar, parkingLot));
            Assert.Equal("Not enough position.", ex.Message);
        }
    }
}
