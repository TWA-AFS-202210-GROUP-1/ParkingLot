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

    public OperationStatus AddCar(Car car)
    {
      if (EmptySlots > 0 && car != null)
      {
        ParkedCars.Add(car);
        EmptySlots--;
        return OperationStatus.Successful;
      }
      else
      {
        return OperationStatus.Failed;
      }
    }

    public OperationStatus RemoveCar(Car car)
    {
      if (HasCar(car) && car != null)
      {
        ParkedCars.Remove(car);
        EmptySlots++;
        return OperationStatus.Successful;
      }
      else
      {
        return OperationStatus.Failed;
      }
    }

    public bool HasCar(Car car)
    {
      return ParkedCars.Contains(car);
    }
  }
}
