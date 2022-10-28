namespace ParkingLotService;

public class Response
{
    public Car Car { get; set; }
    public string Message { get; set; }

    public Response(Car car, string message)
    {
        Car = car;
        Message = message;
    }
}