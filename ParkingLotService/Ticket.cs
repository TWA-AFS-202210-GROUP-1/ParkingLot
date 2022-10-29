using System;
using ParkingLotService.ParkingBoys;

namespace ParkingLotService;

public class Ticket
{
    public string CarLicenseNumber { get; set; }
    public string Code { get; set; }
    public string ParkingLotName { get; set; }

    public Ticket(string carLicenseNumber, string parkingLotName)
    {
        CarLicenseNumber = carLicenseNumber;
        ParkingLotName = parkingLotName;
        Code = "Invalid Code";
    }
}