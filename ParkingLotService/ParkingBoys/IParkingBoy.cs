using System.Collections.Generic;

namespace ParkingLotService.ParkingBoys;

public interface IParkingBoy
{
    public void AssignLot(ParkingLot lot);
    public Response<Ticket> ParkCar(Car car);
    public List<Response<Ticket>> ParkCars(List<Car> cars);
    public Response<Car> FetchCar(Ticket ticket);
}