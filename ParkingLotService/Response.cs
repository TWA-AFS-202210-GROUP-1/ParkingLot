namespace ParkingLotService;

public class Response<T>
    where T : class
{
    public T Content { get; set; }
    public string Message { get; set; }

    public Response(T content, string message)
    {
        Content = content;
        Message = message;
    }
}