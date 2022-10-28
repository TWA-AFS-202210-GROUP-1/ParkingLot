using System.Collections.Generic;
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

        [Fact]
        public void Should_give_several_car_when_parking_boy_parking_given_several_car()
        {
            //given
            var parkingBoy = new ParkingBoy("Parking Boy 01");
            var parkingLot = new ParkingLot("Parking Lot 01");
            parkingBoy.AssignLot(parkingLot);
            var cars = new List<Car>()
            {
                new Car("License Number 01"),
                new Car("License Number 02"),
            };

            //when
            var result = parkingBoy.ParkCars(cars);

            //then
            Assert.Equal(2, result.Count);
            Assert.Equal("License Number 01", result[0].Car.LicenseNumber);
            Assert.Equal("License Number 02", result[1].Car.LicenseNumber);
        }
    }
}
