namespace ParkingLot
{
    using System;
    public class Ticket
    {
        private Car correspondingcar;
        private int number;
        private int status;
        public Ticket(Car car, int number)
        {
            this.correspondingcar = car;
            this.number = number;
            this.status = 1;
        }

        public Ticket()
        {
            this.status = -1;
            this.number = -1;
        }

        public Car Correspondingcar
        {
            get
            {
                return correspondingcar;
            }

            set
            {
                correspondingcar = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
    }
}
