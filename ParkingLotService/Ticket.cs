using ParkingLotService.ParkingBoys;

namespace ParkingLotService;

public class Ticket
{
    public Car Car { get; set; }
    public string Code { get; set; }
    public ParkingLot ParkingLot { get; set; }

    public Ticket(ParkingBoy parkingBoy, Car car, ParkingLot parkingLot)
    {
        Car = car;
        Code = parkingBoy.Name;
        ParkingLot = parkingLot;
    }
}