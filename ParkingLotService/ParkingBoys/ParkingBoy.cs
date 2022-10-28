using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ParkingLotService.Const;

namespace ParkingLotService.ParkingBoys;

public class ParkingBoy
{
    public string Name { get; }
    protected List<ParkingLot> ManagingLots { get; set; }
    protected string Token { get; set; }
    public ParkingBoy(string name)
    {
        Name = name;
        Token = Guid.NewGuid().ToString();
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
                var ticket = SignTicket(new Ticket(this, car, lot));
                return new Response<Ticket>(ticket, ParkingBoyConst.GenerateTicketMessage);
            }
        }

        return new Response<Ticket>(null, ParkingBoyConst.NoPositionMessage);
    }

    public List<Response<Ticket>> ParkCars(List<Car> cars)
    {
        return cars.Select(ParkCar).ToList();
    }

    public Response<Car> FetchCar(Ticket ticket)
    {
        if (ticket == null)
        {
            return new Response<Car>(null, ParkingBoyConst.NullTicketMessage);
        }

        if (IsValidTicket(ticket))
        {
            var thisCarParkingLotName = ticket.ParkingLot.Name;
            var lot = ManagingLots.Find(lot => lot.Name.Equals(thisCarParkingLotName));
            var car = lot?.PopCar(ticket.Car.LicenseNumber);
            if (car != null)
            {
                return new Response<Car>(car, ParkingBoyConst.GetCarMessage);
            }
        }

        return new Response<Car>(null, ParkingBoyConst.WrongTicketMessage);
    }

    protected Ticket SignTicket(Ticket ticket)
    {
        ticket.Code = GenerateMd5CodeForTicket(ticket.Car);
        return ticket;
    }

    private bool IsValidTicket(Ticket ticket)
    {
        var expectTicketCode = GenerateMd5CodeForTicket(ticket.Car);
        return string.Equals(expectTicketCode, ticket.Code);
    }

    private string GenerateMd5CodeForTicket(Car car)
    {
        // Use input string to calculate MD5 hash
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(Name + car.LicenseNumber + Token);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}