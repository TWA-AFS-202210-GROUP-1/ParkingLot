using System.Net.Sockets;

namespace ParkingLotService;

public class ParkingBoy
{
    private ParkingLot _managingLot;
    public ParkingBoy(string name)
    {
        Name = name;
    }

    public Ticket ParkCar(Car car)
    {
        if (_managingLot.AddCar(car))
        {
            return new Ticket(this, car);
        }

        return null;
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

    public Car FetchCar(Ticket ticket)
    {
        return _managingLot.PopCar(ticket.Car.LicenseNumber);
    }
}