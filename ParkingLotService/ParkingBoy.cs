using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using ParkingLotService.Const;

namespace ParkingLotService;

public class ParkingBoy
{
    private List<ParkingLot> _managingLots;
    private string _token;
    public string Name { get; }
    public ParkingBoy(string name)
    {
        Name = name;
        _token = Guid.NewGuid().ToString();
        _managingLots = new List<ParkingLot>();
    }

    public void AssignLot(ParkingLot lot)
    {
        _managingLots.Add(lot);
    }

    public Response<Ticket> ParkCar(Car car)
    {
        foreach (var lot in _managingLots)
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
            var lot = _managingLots.Find(lot => lot.Name.Equals(thisCarParkingLotName));
            var car = lot?.PopCar(ticket.Car.LicenseNumber);
            if (car != null)
            {
                return new Response<Car>(car, ParkingBoyConst.GetCarMessage);
            }
        }

        return new Response<Car>(null, ParkingBoyConst.WrongTicketMessage);
    }

    private bool IsValidTicket(Ticket ticket)
    {
        var expectTicketCode = GenerateMd5CodeForTicket(ticket.Car);
        return string.Equals(expectTicketCode, ticket.Code);
    }

    private Ticket SignTicket(Ticket ticket)
    {
        ticket.Code = GenerateMd5CodeForTicket(ticket.Car);
        return ticket;
    }

    private string GenerateMd5CodeForTicket(Car car)
    {
        // Use input string to calculate MD5 hash
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(Name + car.LicenseNumber + _token);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}