namespace ParkingLot
{
  public class Response
  {
    private readonly Car car;
    private readonly Ticket ticket;
    private readonly OperationStatus operationStatus;
    private readonly bool isNullTicket;
    private readonly bool isValidTicket;
    private string errorMessage = string.Empty;

    public Response(Car car, Ticket ticket, OperationStatus operationStatus)
    {
      this.car = car;
      this.ticket = ticket;
      this.operationStatus = operationStatus;
      isNullTicket = ticket == null;
      isValidTicket = ticket != null && car != null;
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
      if (operationStatus == OperationStatus.NoVacancy)
      {
        errorMessage = "Not enough position.";
      }
      else if (isNullTicket)
      {
        errorMessage = "Please provide your parking ticket.";
      }
      else if (!isValidTicket)
      {
        errorMessage = "Unrecognized parking ticket.";
      }

      return errorMessage;
    }
  }
}
