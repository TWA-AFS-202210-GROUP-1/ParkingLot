namespace ParkingLotSystemTest
{
    using Moq;
    using ParkingLotSystem;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ParkinBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_parked_into_parking_lot_given_customer_and_parking_boy()
        {
            //given
            ParkingLot parkingLot = new ParkingLot("1");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.AssignParkingLot(parkingLot);
            Car car = new Car("1234");
            //when
            Ticket ticket = parkingBoy.HelpParkCar(car).Ticket;
            //then
            Assert.Equal("1234", ticket.CarNum);
            Assert.Equal(1, parkingLot.Cars.Count);
        }

        [Fact]
        public void Should_return_carNum_when_fetch_car_given_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot("1");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.AssignParkingLot(parkingLot);
            Car car = new Car("1234");
            Ticket ticket = parkingBoy.HelpParkCar(car).Ticket;
            //when
            Car fetchedcar = parkingBoy.HelpFetchCar(ticket).Car;
            //then
            Assert.Equal("1234", fetchedcar.CarNum);
        }

        [Fact]
        public void Should_return_tickets_when_parking_cars_given_cars()
        {
            //given
            ParkingLot parkingLot = new ParkingLot("1");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.AssignParkingLot(parkingLot);
            List<Car> cars = new List<Car>() { new Car(carNum: "11"), new Car(carNum: "12"), new Car(carNum: "13") };
            //when
            List<Ticket> tickets = parkingBoy.HelpParkCar(cars).Select(repsonse => repsonse.Ticket).ToList();
            //then
            Assert.Equal(3, tickets.Count);
            Assert.Equal("11", tickets[0].CarNum);
            Assert.Equal("12", tickets[1].CarNum);
            Assert.Equal("13", tickets[2].CarNum);
        }

        [Fact]
        public void Should_throw_err_msg_when_fetching_cars_given_wrong_ticket_or_no_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot("1");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.AssignParkingLot(parkingLot);
            Car car = new Car("1234");
            _ = parkingBoy.HelpParkCar(car);
            //when
            string msg = parkingBoy.HelpFetchCar().FetchMsg;
            //then
            Assert.Equal("Please provide your parking ticket.", msg);
            //when
            string res = parkingBoy.HelpFetchCar(new Ticket
            {
                CarNum = "111",
                LotId = "3",
            }).FetchMsg;
            //then
            Assert.Equal("Unrecognized parking ticket.", res);
            Assert.Equal(1, parkingLot.Cars.Count);
        }

        [Fact]
        public void Should_throw_no_space_err_msg_when_parking_cars_given_not_enough_parking_spots()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(1, "1");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.AssignParkingLot(parkingLot);
            Car car = new Car("1234");
            _ = parkingBoy.HelpParkCar(car);
            //when
            Car newCar = new Car("1233");
            string msg = parkingBoy.HelpParkCar(newCar).ParkMsg;
            //then
            Assert.Equal("Not enough position.", msg);
        }
    }
}
