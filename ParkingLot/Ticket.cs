using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(string carName)
        {
            CarName = carName;
        }

        public string CarName { get; set; }
        public int PositionNumber { get; set; }
        public bool Isused { get; set; }
    }
}
