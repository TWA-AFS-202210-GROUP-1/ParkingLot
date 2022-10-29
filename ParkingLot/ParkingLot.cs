using System.Collections.Generic;

namespace ParkingLot
{
  public class ParkingLot
  {
    public ParkingLot(int capacity = 10)
    {
      Capacity = capacity;
      EmptySlots = Capacity;
    }

    public List<Car> ParkedCars { get; private set; } = new List<Car>();
    public int Capacity { get; private set; }
    public int EmptySlots { get; private set; }

    public void AddCar(Car car)
    {
      if (EmptySlots > 0)
      {
        ParkedCars.Add(car);
        EmptySlots--;
      }
    }

    public void RemoveCar(Car car)
    {
      if (HasCar(car) && car != null)
      {
        ParkedCars.Remove(car);
        EmptySlots--;
      }
    }

    public bool HasCar(Car car)
    {
      return ParkedCars.Contains(car);
    }
  }
}
