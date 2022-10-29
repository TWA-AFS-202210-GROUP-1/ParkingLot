using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace ParkingLotTest
{
    using ParkingLot;
    using System.Text.RegularExpressions;
    using Xunit;

    public class CarLotTest
    {
        [Fact]
        public void Should_return_true_when_lot_success_add_car_given_a_car()
        {
            // given
            var carLot = new CarLot("lotID");
            var car = new Car("ThisIsLicensePlate");
            // when
            var isSucceAddCar = carLot.AddCar(car);
            // then
            Assert.True(isSucceAddCar);
        }

        [Fact]
        public void Should_return_car_when_lot_success_delete_car_given_a_car()
        {
            // given
            var carLot = new CarLot("LotID");
            var car = new Car("ThisIsLicensePlate");
            carLot.AddCar(car);
            // when
            var deleteCar = carLot.DeleteCar(car);
            // then
            Assert.Equal(car, deleteCar);
        }

        [Fact]
        public void Should_return_null_when_lot_fail_to_delete_car_given_a_car()
        {
            // given
            var carLot = new CarLot("LotID");
            var car = new Car("ThisIsLicensePlate");
            // when
            var deleteCar = carLot.DeleteCar(car);
            // then
            Assert.Null(deleteCar);
        }
    }
}
