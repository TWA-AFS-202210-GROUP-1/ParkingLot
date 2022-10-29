namespace ParkingLot
{
  public class Response
  {
    private readonly Car car;
    private readonly Ticket ticket;
    private readonly bool isValidTicket;
    private string errorMessage = string.Empty;

    public Response(Car car, Ticket ticket)
    {
      this.car = car;
      this.ticket = ticket;
      isValidTicket = car != null && ticket != null;
    }

    public Car ShowCar()
    {
      return car;
    }

    public Ticket ShowTicket()
    {
      return ticket;
    }

    public string ShowErrorMessage()
    {
      if (!isValidTicket)
      {
        errorMessage = "Unrecognized parking ticket.";
      }

      return errorMessage;
    }
  }
}
