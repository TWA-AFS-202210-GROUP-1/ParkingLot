namespace ParkingLotTest
{
    using ParkingLot;
    using System.Text.RegularExpressions;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_parking_boy_park_a_car_given_a_car()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var car = new Car("ThisIsLicensePlate");
            // when
            var ticket = parkingBoy.ParkCar(car);
            // then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_a_car_when_parking_boy_fetch_a_car_given_a_ticket()
        {
            // given
            var parkingBoy = new ParkingBoy();
            var car = new Car("ThisIsLicensePlate");
            var ticket = parkingBoy.ParkCar(car);
            // when
            var licensePlate = parkingBoy.FetchCar(ticket);
            // then
            Assert.Equal("ThisIsLicensePlate", licensePlate);
        }
    }
}
