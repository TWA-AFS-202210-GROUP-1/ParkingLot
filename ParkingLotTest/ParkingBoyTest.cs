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
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Customer customer = new Customer("1234");
            //when
            Ticket ticket = customer.ParkCar(customer.CarNum, parkingBoy);
            //then
            Assert.Equal("1234", ticket.CarNum);
            Assert.Equal("1234", parkingBoy.TicketsList[0].CarNum);
        }

        [Fact]
        public void Should_return_carNum_when_fetch_car_given_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Customer customer = new Customer("1234");
            Ticket ticket = customer.ParkCar(customer.CarNum, parkingBoy);
            //when
            string carNum = customer.FetchCar(ticket, parkingBoy);
            //then
            Assert.Equal("1234", carNum);
        }

        [Fact]
        public void Should_return_tickets_when_parking_cars_given_cars()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            List<string> carsNums = new List<string>() { "11", "12", "13" };
            //when
            List<Ticket> tickets = parkingBoy.HelpParkCar(carsNums);
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
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            parkingBoy.TicketsList = new List<Ticket>() { new Ticket { CarNum = "1234", TicketNum = "1234" }, new Ticket { CarNum = "1233", TicketNum = "1233" } };
            //when
            Action notGivenTicket = () => parkingBoy.HelpFetchCar();
            //then
            var noTicketError = Assert.Throws<Exception>(notGivenTicket);
            Assert.Equal("Please provide your parking ticket.", noTicketError.Message);
            //when
            Action givenWrongTicket = () => parkingBoy.HelpFetchCar(new Ticket
            {
                CarNum = "111",
                TicketNum = "111",
            });
            //then
            var wrongTicketError = Assert.Throws<Exception>(givenWrongTicket);
            Assert.Equal("Unrecognized parking ticket.", wrongTicketError.Message);
            Assert.Equal(2, parkingBoy.TicketsList.Count);
        }

        [Fact]
        public void Should_throw_no_space_err_msg_when_parking_cars_given_not_enough_parking_spots()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(1);
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            //when
            parkingBoy.HelpParkCar("1234");
            Action parkToLotWithNoSpace = () => parkingBoy.HelpParkCar("1233");
            //then
            var noSpaceError = Assert.Throws<Exception>(parkToLotWithNoSpace);
            Assert.Equal("Not enough position.", noSpaceError.Message);
        }
    }
}
