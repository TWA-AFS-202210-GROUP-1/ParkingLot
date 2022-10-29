using System.Collections.Generic;

namespace ParkingLot
{
  public class ParkingLot
  {
    public List<Car> ParkedCars { get; private set; } = new List<Car>();

    public void AddCar(Car car)
    {
      ParkedCars.Add(car);
    }

    public bool HasCar(Car car)
    {
      return ParkedCars.Contains(car);
    }
  }
}
