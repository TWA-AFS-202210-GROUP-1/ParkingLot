using System.Collections.Generic;

namespace ParkingLot
{
  public class Response
  {
    private readonly Car car = null;
    private readonly List<Car> cars = null;
    private readonly Ticket ticket = null;
    private readonly List<Ticket> tickets = null;
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

    public Response(List<Car> cars, List<Ticket> tickets, OperationStatus operationStatus)
    {
      this.cars = cars;
      this.tickets = tickets;
      this.operationStatus = operationStatus;
      isNullTicket = ticket == null;
      isValidTicket = ticket != null && car != null;
    }

    public Car ShowCar()
    {
      return car;
    }

    public List<Car> ShowCars()
    {
      return cars;
    }

    public Ticket ShowTicket()
    {
      return ticket;
    }

    public List<Ticket> ShowTickets()
    {
      return tickets;
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
