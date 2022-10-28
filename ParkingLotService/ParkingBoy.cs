using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace ParkingLotService;

public class ParkingBoy
{
    private ParkingLot _managingLot;
    private string _token;
    public ParkingBoy(string name)
    {
        Name = name;
        _token = Guid.NewGuid().ToString();
    }

    public Ticket ParkCar(Car car)
    {
        if (_managingLot.AddCar(car))
        {
            return SignTicket(new Ticket(this, car));
        }

        return null;
    }

    public List<Ticket> ParkCars(List<Car> cars)
    {
        return cars.Select(ParkCar).ToList();
    }

    public void AssignLot(ParkingLot lot)
    {
        if (_managingLot == null)
        {
            _managingLot = lot;
            _managingLot.ParkingBoy = this;
        }
    }

    public string Name { get; }

    public Response FetchCar(Ticket ticket)
    {
        if (IsValidTicket(ticket))
        {
            return new Response(_managingLot.PopCar(ticket.Car.LicenseNumber), "Here is your Car.");
        }

        return new Response(null, "Unrecognized parking ticket.");
    }

    private bool IsValidTicket(Ticket ticket)
    {
        if (ticket == null)
        {
            return false;
        }

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