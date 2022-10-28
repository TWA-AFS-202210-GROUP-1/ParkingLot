using ParkingLotService.Const;
using System.Linq;

namespace ParkingLotService.ParkingBoys
{
    public class CleverParkingBoy : ParkingBoy
    {
        public CleverParkingBoy(string name) : base(name)
        {
        }

        public override Response<Ticket> ParkCar(Car car)
        {
            var lot = ManagingLots.MaxBy(_ => _.MaxCapacity - _.CarNumber);
            if (lot != null && lot.AddCar(car))
            {
                var ticket = SignTicket(new Ticket(this, car, lot));
                return new Response<Ticket>(ticket, ParkingBoyConst.GenerateTicketMessage);
            }

            return new Response<Ticket>(null, ParkingBoyConst.NoPositionMessage);
        }
    }
}
