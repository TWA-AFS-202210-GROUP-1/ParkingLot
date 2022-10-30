namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ParkinBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_parked_into_parking_lot_given_customer_and_parking_boy()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Customer customer = new Customer("1234");
            //var mockTicketNumGenerator = new Mock<TicketNumGenerator>();
            //mockTicketNumGenerator.Setup(t => t.GenerateTicketNum()).Returns("1234");
            Ticket expectTicket = new Ticket() { CarNum = "1234", TicketNum = "1234" };
            //when
            Ticket ticket = customer.ParkCar(customer.CarNum, parkingBoy);
            //then
            //Assert.Equal(expectTicket.TicketNum, ticket.TicketNum);
            Assert.Equal(expectTicket.CarNum, ticket.CarNum);
            Assert.Equal(expectTicket.CarNum, parkingBoy.TicketsList[0].CarNum);
        }

        [Fact]
        public void Should_return_bool_when_fetch_car_given_ticket()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            Customer customer = new Customer("1234");
            Ticket ticket = customer.ParkCar(customer.CarNum, parkingBoy);
            //when
            var res = customer.FetchCar(ticket, parkingBoy);
            //then
            Assert.True(res);
        }

        [Fact]
        public void Should_return_tickets_when_parking_cars_given_cars()
        {
            //given
            ParkingBoy parkingBoy = new ParkingBoy();
            List<string> carsNums = new List<string>() { "11", "12", "13" };
            //when
            List<Ticket> tickets = parkingBoy.HelpParkCar(carsNums);
            //then
            Assert.Equal(3, tickets.Count);
            Assert.Equal("11", tickets[0].CarNum);
            Assert.Equal("12", tickets[1].CarNum);
            Assert.Equal("13", tickets[2].CarNum);
        }
    }
}
