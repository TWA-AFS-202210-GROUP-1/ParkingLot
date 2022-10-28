using System.Collections.Generic;

namespace ParkingLot
{
  public class ParkingLot
  {
    public List<Car> ParkedCars { get; set; } = new List<Car>();

    public void AddCar(Car car)
    {
      ParkedCars.Add(car);
    }
  }
}
