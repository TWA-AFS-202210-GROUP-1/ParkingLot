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
        _managingLot ??= lot;
    }

    public string Name { get; }
}