namespace ParkingLotService;

public class Car
{
    public string LicenseNumber { get; set; }
    public Car(string licenseNumber)
    {
        LicenseNumber = licenseNumber;
    }
}