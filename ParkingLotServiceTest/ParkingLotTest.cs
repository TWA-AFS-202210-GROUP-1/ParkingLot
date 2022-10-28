using ParkingLotService;
using Xunit;

namespace ParkingLotServiceTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_true_when_add_car_successfully_when_given_car()
        {
            //given
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");

            //when
            var result = parkingLot.AddCar(car);

            //then
            Assert.True(result);
        }

        [Fact]
        public void Should_return_car_when_pop_car_given_license_number_car_exist()
        {
            //given
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingLot.AddCar(car);

            //when
            var result = parkingLot.PopCar("License Number");

            //then
            Assert.NotNull(result);
            Assert.Equal("License Number", result.LicenseNumber);
        }

        [Fact]
        public void Should_return_null_when_pop_car_given_license_number_car_not_exist()
        {
            //given
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            parkingLot.AddCar(car);

            //when
            var result = parkingLot.PopCar("License Number 01");

            //then
            Assert.Null(result);
        }
    }
}
