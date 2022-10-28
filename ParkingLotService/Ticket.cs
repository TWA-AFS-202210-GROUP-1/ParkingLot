namespace ParkingLotService;

public class Ticket
{
    public Car Car { get; set; }
    public string Code { get; set; }

    public Ticket(ParkingBoy parkingBoy, Car car)
    {
        Car = car;
        Code = parkingBoy.Name;
    }
}