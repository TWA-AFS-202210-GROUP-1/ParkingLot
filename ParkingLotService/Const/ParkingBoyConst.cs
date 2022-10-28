using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotService.Const
{
    public static class ParkingBoyConst
    {
        //wrong message
        public const string WrongTicketMessage = "Unrecognized parking ticket.";
        public const string NullTicketMessage = "Please provide your parking ticket.";
        public const string NoPositionMessage = "Not enough position.";

        //happy message
        public const string GetCarMessage = "Here is your car.";
        public const string GenerateTicketMessage = "Here is your ticket.";
    }
}
