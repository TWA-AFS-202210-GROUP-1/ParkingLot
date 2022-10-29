namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class Parkinglot
    {
        private string name;
        private int capacity;
        private int currentcarnum;
        private int ticketnumber;
        private List<int> parkingspace;

        public Parkinglot(string name, int capacity)
        {
            this.name = name;
            this.capacity = capacity;
            this.ticketnumber = 1;
            this.currentcarnum = 0;
            this.parkingspace = new List<int>(new int[capacity]);
            for (int i = 0; i < capacity; i++)
            {
                parkingspace[i] = 0;
            }
        }

        public List<int> Parkingspace
        {
            get
            {
                return parkingspace;
            }

            set
            {
                parkingspace = value;
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
    }
}
