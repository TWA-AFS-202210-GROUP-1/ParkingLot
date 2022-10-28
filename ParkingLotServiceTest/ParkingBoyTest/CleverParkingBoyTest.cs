using System.Collections.Generic;
using ParkingLotService.ParkingBoys;
using ParkingLotService;
using ParkingLotService.Const;
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
            var parkingLot02 = new ParkingLot("Parking Lot 02");
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

        [Fact]
        public void Should_add_car_to_more_position_lot_when_clever_parking_boy_park_car_when_park_multiple_car_and_car_number_lower_than_empty_position_number()
        {
            //given
            var parkingBoy = new CleverParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            parkingLot01.SeMaxCapacity(5);
            var parkingLot02 = new ParkingLot("Parking Lot 02");
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var cars = new List<Car>()
            {
                new Car("License NUmber 01"),
                new Car("License NUmber 02"),
                new Car("License NUmber 03"),
                new Car("License NUmber 04"),
                new Car("License NUmber 05"),
                new Car("License NUmber 06"),
            };

            //when
            var response = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(6, response.Count);
            Assert.Equal(0, parkingLot01.CarNumber);
            Assert.Equal(6, parkingLot02.CarNumber);
        }

        [Fact]
        public void Should_add_car_to_more_position_lot_first_when_clever_parking_boy_park_car_when_park_multiple_car_and_car_number_larger_than_empty_position_number()
        {
            //given
            var parkingBoy = new CleverParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            parkingLot01.SeMaxCapacity(2);
            var parkingLot02 = new ParkingLot("Parking Lot 02");
            parkingLot02.SeMaxCapacity(4);
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var cars = new List<Car>()
            {
                new Car("License NUmber 01"),
                new Car("License NUmber 02"),
                new Car("License NUmber 03"),
                new Car("License NUmber 04"),
                new Car("License NUmber 05"),
            };

            //when
            var response = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(5, response.Count);
            Assert.Equal(1, parkingLot01.CarNumber);
            Assert.Equal(4, parkingLot02.CarNumber);
        }

        [Fact]
        public void Should_return_some_null_when_clever_parking_boy_park_car_when_park_multiple_car_and_car_number_larger_than_all_empty_position_number()
        {
            //given
            var parkingBoy = new CleverParkingBoy("Parking Boy 01");
            var parkingLot01 = new ParkingLot("Parking Lot 01");
            parkingLot01.SeMaxCapacity(2);
            var parkingLot02 = new ParkingLot("Parking Lot 02");
            parkingLot02.SeMaxCapacity(4);
            parkingBoy.AssignLot(parkingLot01);
            parkingBoy.AssignLot(parkingLot02);
            var cars = new List<Car>()
            {
                new Car("License NUmber 01"),
                new Car("License NUmber 02"),
                new Car("License NUmber 03"),
                new Car("License NUmber 04"),
                new Car("License NUmber 05"),
                new Car("License NUmber 06"),
                new Car("License NUmber 07"),
            };

            //when
            var response = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(7, response.Count);
            Assert.Equal(2, parkingLot01.CarNumber);
            Assert.Equal(4, parkingLot02.CarNumber);
            Assert.Equal(ParkingBoyConst.NoPositionMessage, response[6].Message);
        }
    }
}
