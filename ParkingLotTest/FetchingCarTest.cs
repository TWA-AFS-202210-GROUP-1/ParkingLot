namespace ParkingLotTest
{
    using DeepEqual.Syntax;
    using ParkingLot;
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
    }
}
