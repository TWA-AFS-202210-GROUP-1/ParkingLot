using ParkingLotService.ParkingBoys;
using ParkingLotService;
using Xunit;

namespace ParkingLotServiceTest.ParkingBoyTest
{
    public class CleverParkingBoyTest
    {
        [Fact]
        public void Should_add_car_to_more_position_lot_when_clever_parking_boy_park_car_when_park_one_car()
        {
            //given
            var parkingBoy = new CleverParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            parkingLot01.SeMaxCapacity(5);
            var parkingLot02 = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var car = new Car("License NUmber");

            //when
            var response = parkingBoy.ParkCar(car);

            //then
            Assert.NotNull(response.Content);
            Assert.Equal(0, parkingLot01.CarNumber);
            Assert.Equal(1, parkingLot02.CarNumber);
        }
    }
}
