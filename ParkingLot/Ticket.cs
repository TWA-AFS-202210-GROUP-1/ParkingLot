using System;

namespace ParkingLotSystem
{
    public class Ticket
    {
        private string carNum;
        private string lotId;

        public Ticket()
        {
        }

        public Ticket(string carNum, string lotId)
        {
            this.CarNum = carNum;
            this.LotId = lotId;
        }

        public string CarNum { get => carNum; set => carNum = value; }
        public string LotId { get => lotId; set => lotId = value; }
    }
}