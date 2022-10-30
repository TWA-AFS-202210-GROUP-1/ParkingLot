namespace ParkingLotTest
{
    using DeepEqual.Syntax;
    using ParkingLot;
    using System.Collections.Generic;
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
            var exceptedResult = new List<Ticket>()
            {
                new Ticket(carId: "Tom", parkingLotId: "Lot1", parkingBoyId: "boy1"),
                new Ticket(carId: "Jim", parkingLotId: "Lot1", parkingBoyId: "boy1"),
                new Ticket(carId: "Alice", parkingLotId: "Lot1", parkingBoyId: "boy1"),
            };

            //when
            var parkingResult = parkingBoy.ParkingCar(carlist, parkingLot);

            //then
            parkingResult.ShouldDeepEqual(exceptedResult);
        }
    }
}
