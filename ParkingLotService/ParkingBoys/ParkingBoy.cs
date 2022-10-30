using ParkingLotService.Const;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ParkingLotService.ParkingBoys;

public class ParkingBoy
{
    public string Name { get; }
    protected List<ParkingLot> ManagingLots { get; set; }
    private readonly string _token;
    public ParkingBoy(string name)
    {
        Name = name;
        _token = Guid.NewGuid().ToString();
        ManagingLots = new List<ParkingLot>();
    }

    public void AssignLot(ParkingLot lot)
    {
        ManagingLots.Add(lot);
    }

    public virtual Response<Ticket> ParkCar(Car car)
    {
        foreach (var lot in ManagingLots)
        {
            if (lot.AddCar(car))
            {
                var ticket = SignTicket(new Ticket(car.LicenseNumber, lot.Name));
                return new Response<Ticket>(ticket, ParkingBoyConst.GenerateTicketMessage);
            }
        }

        return new Response<Ticket>(null, ParkingBoyConst.NoPositionMessage);
    }

    public virtual List<Response<Ticket>> ParkCars(List<Car> cars)
    {
        var tickets = new List<Response<Ticket>>();
        foreach (var lot in ManagingLots)
        {
            while (lot.CarCount < lot.MaxCapacity && tickets.Count < cars.Count)
            {
                if (lot.AddCar(cars[tickets.Count]))
                {
                    var ticket = SignTicket(new Ticket(cars[tickets.Count].LicenseNumber, lot.Name));
                    tickets.Add(new Response<Ticket>(ticket, ParkingBoyConst.GenerateTicketMessage));
                }
            }
        }

        AddNullTickets(cars, tickets);

        return tickets;
    }

    public Response<Car> FetchCar(Ticket ticket)
    {
        if (ticket == null)
        {
            return new Response<Car>(null, ParkingBoyConst.NullTicketMessage);
        }

        if (IsValidTicket(ticket))
        {
            var thisCarParkingLotName = ticket.ParkingLotName;
            var lot = ManagingLots.Find(lot => lot.Name.Equals(thisCarParkingLotName));
            var car = lot?.PopCar(ticket.CarLicenseNumber);

            if (car != null)
            {
                return new Response<Car>(car, ParkingBoyConst.GetCarMessage);
            }
        }

        return new Response<Car>(null, ParkingBoyConst.WrongTicketMessage);
    }

    protected Ticket SignTicket(Ticket ticket)
    {
        ticket.Code = GenerateMd5CodeForTicket(ticket.CarLicenseNumber);
        return ticket;
    }

    private bool IsValidTicket(Ticket ticket)
    {
        var expectTicketCode = GenerateMd5CodeForTicket(ticket.CarLicenseNumber);
        return string.Equals(expectTicketCode, ticket.Code);
    }

    private string GenerateMd5CodeForTicket(string carLicenseNumber)
    {
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(Name + carLicenseNumber + _token);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }

    private void AddNullTickets(List<Car> cars, List<Response<Ticket>> tickets)
    {
        while (tickets.Count < cars.Count)
        {
            tickets.Add(new Response<Ticket>(null, ParkingBoyConst.NoPositionMessage));
        }
    }
}