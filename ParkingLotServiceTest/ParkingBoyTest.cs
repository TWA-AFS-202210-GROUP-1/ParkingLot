using ParkingLotService;
using Xunit;

namespace ParkingLotServiceTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_give_a_ticket_when_parking_boy_parking_given_a_car()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingBoy.AssignLot(parkingLot);
            //when

            var result = parkingBoy.ParkCar(car);

            //then
            Assert.NotNull(result);
        }

        [Fact]
        public void Should_give_a_car_when_parking_boy_parking_given_a_ticket()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingBoy.AssignLot(parkingLot);

            var ticket = parkingBoy.ParkCar(car);
            //when

            var result = parkingBoy.FetchCar(ticket);

            //then
            Assert.NotNull(result);
            Assert.Equal("License Number", car.LicenseNumber);
        }
    }
}
