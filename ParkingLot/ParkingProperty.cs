namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingProperty
    {
        private string name;
        private int totalcapacity;
        private int currentcarnum;
        private int ticketnumber;
        private List<Parkinglot> parkinglots;
        private List<ParkingBoy> parkingboys;

        public ParkingProperty(string name)
        {
            this.name = name;
            this.parkinglots = new List<Parkinglot>();
            this.parkingboys = new List<ParkingBoy>();
            //this.totalcapacity = 0;
            //foreach (Parkinglot parkinglot in parkinglots)
            //{
            //    this.totalcapacity += parkinglot.Capacity;
            //}
            this.totalcapacity = 0;
            this.ticketnumber = 1;
            this.currentcarnum = 0;
        }

        public List<Parkinglot> Parkinglots
        {
            get
            {
                return parkinglots;
            }

            set
            {
                parkinglots = value;
            }
        }

        public List<ParkingBoy> ParkingBoys
        {
            get
            {
                return parkingboys;
            }

            set
            {
                parkingboys = value;
            }
        }

        public int Ticketnumber
        {
            get
            {
                return ticketnumber;
            }

            set
            {
                ticketnumber = value;
            }
        }

        public int Currentcarnum
        {
            get
            {
                return currentcarnum;
            }

            set
            {
                currentcarnum = value;
            }
        }

        public void Addparkinglot(Parkinglot parkinglot)
        {
            this.parkinglots.Add(parkinglot);
            this.totalcapacity += parkinglot.Capacity;
        }

        public void Addparkingboy(ParkingBoy parkingboy)
        {
            this.parkingboys.Add(parkingboy);
        }
    }
}
