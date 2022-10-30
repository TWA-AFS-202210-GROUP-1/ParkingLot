namespace ParkingLotTest
{
    using ParkingLot;
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

            //when
            var parkingResult = parkingBoy.ParkingCar(car, parkingLot);

            //then
            Assert.Equal(exceptedResult.CarId, parkingResult.CarId);
            Assert.Equal(exceptedResult.ParkingLotId, parkingResult.ParkingLotId);
            Assert.Equal(exceptedResult.ParkingBoyId, parkingResult.ParkingBoyId);
        }
    }
}
