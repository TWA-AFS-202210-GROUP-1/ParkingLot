namespace ParkingLotService;

public class ParkingBoy
{
    public ParkingBoy(string name)
    {
        Name = name;
    }

    public Ticket ParkCar(Car car)
    {
        return new Ticket(this, car);
    }

    public string Name { get; }
}