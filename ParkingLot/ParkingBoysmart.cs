namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingBoysmart : ParkingBoy
    {
        private ParkingProperty parkingproperty;
        private List<string> messages;
        private string personalizedmessage;
        private bool taskdone;

        public ParkingBoysmart(ParkingProperty parkingproperty) : base(parkingproperty)
        {
            this.parkingproperty = parkingproperty;
            this.taskdone = false;
            this.messages = new List<string>(new string[] { "Unrecognized parking ticket.", "Please provide your parking ticket.", "Not enough position.", "All good Dude." });
        }

        public override void Checkin(Car car)
        {
            Ticket ticket = new Ticket(car: car, number: parkingproperty.Ticketnumber);

            List<int> emptyplaces = new List<int>();

            for (int i = 0; i < parkingproperty.Parkinglots.Count; i++)
            {
                var zeros = 0;
                for (int j = 0; j < parkingproperty.Parkinglots[i].Capacity; j++)
                {
                    if (parkingproperty.Parkinglots[i].Parkingspace[j] == 0)
                    {
                        zeros++;
                    }
                }

                emptyplaces.Add(zeros);
            }

            int max = emptyplaces.Max();
            int maxindex = emptyplaces.IndexOf(max);

            parkingproperty.Ticketnumber++;
            parkingproperty.Currentcarnum++;
            parkingproperty.Parkinglots[maxindex].Currentcarnum++;
            for (int i = 0; i < parkingproperty.Parkinglots[maxindex].Parkingspace.Count; i++)
            {
                if (parkingproperty.Parkinglots[maxindex].Parkingspace[i] == 0)
                {
                    parkingproperty.Parkinglots[maxindex].Parkingspace[i] = ticket.Number;
                    car.Parking(ticket, 1);
                    this.personalizedmessage = this.messages[3];
                    taskdone = true;
                    break;
                }
            }

            ticket.Status = -1;
            this.personalizedmessage = this.messages[2];
        }
    }
}
