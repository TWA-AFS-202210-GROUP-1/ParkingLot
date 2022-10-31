using ParkingLotService;
using Xunit;

namespace ParkingLotServiceTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_car_count_should_be_1_when_add_car_successfully_when_given_car()
        {
            //given
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");

            //when
            parkingLot.AddCar(car);
            var result = parkingLot.CarCount;

            //then
            Assert.Equal(1, result);
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

        [Fact]
        public void Should_return_false_when_get_is_full_given_a_full_parking_lot()
        {
            //given
            var parkingLot = new ParkingLot("Parking Lot 01");
            var car = new Car("License Number");
            for (int i = 0; i < 10; i++)
            {
                parkingLot.AddCar(car);
            }

            //when
            var result = parkingLot.IsNotFull;

            //then
            Assert.False(result);
        }
    }
}
