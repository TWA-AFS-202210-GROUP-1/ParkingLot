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

    public void RemoveCar(Car car)
    {
      if (HasCar(car) && car != null)
      {
        ParkedCars.Remove(car);
      }
    }

    public bool HasCar(Car car)
    {
      return ParkedCars.Contains(car);
    }
  }
}
