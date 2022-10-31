namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1 = new Class1();
            Assert.NotNull(class1);
        }

        [Fact]
        public void Should_return_parking_ticket_when_customer_parking_given_parkingboy_a_car()
        {
            // given
            var car = new Car("bentian");
            var customer = new Customer("Zhang San", car);
            var parkingBoy = new ParkingBoy();
            // when
            var ticket = customer.ParkCar(parkingBoy);
            // then
            Assert.Equal(car.Name, ticket.CarName);
        }

        [Fact]
        public void Should_return_car_when_customer_fetch_car_given_parkingboy_ticket()
        {
            // given
            var car = new Car("bentian");
            var customer = new Customer("Zhang San", car);
            var parkingBoy = new ParkingBoy();
            var ticket = customer.ParkCar(parkingBoy);

            //when
            var fetchedCar = customer.FetchCar(parkingBoy);

            // then
            Assert.Equal(car.Name, fetchedCar.Name);
        }
    }
}
