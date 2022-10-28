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
            var parkingBoy = new ParkingBoy("ParkingBoy");
            var car = new Car("License Number");
            //when

            var result = parkingBoy.ParkCar(car);

            //then
            Assert.NotNull(result);
        }
    }
}
