using System;
using System.Collections.Generic;

namespace ParkingLot
{
  public class ParkingLot
  {
    public ParkingLot(int capacity = 10)
    {
      Id = Guid.NewGuid();
      Capacity = capacity;
      EmptySlots = Capacity;
    }

    public Guid Id { get; private set; }
    public List<Car> ParkedCars { get; private set; } = new List<Car>();
    public int Capacity { get; private set; }
    public int EmptySlots { get; private set; }

    public OperationStatus AddCar(Car car)
    {
      if (EmptySlots > 0 && car != null && !HasCar(car))
      {
        ParkedCars.Add(car);
        EmptySlots--;
        return OperationStatus.ParkingSuccessful;
      }
      else if (EmptySlots == 0)
      {
        return OperationStatus.NoVacancy;
      }
      else
      {
        return OperationStatus.ParkingFailed;
      }
    }

    public OperationStatus RemoveCar(Car car)
    {
      if (HasCar(car) && car != null)
      {
        ParkedCars.Remove(car);
        EmptySlots++;
        return OperationStatus.RemovingSuccessful;
      }
      else
      {
        return OperationStatus.RemovingFailed;
      }
    }

    public bool HasCar(Car car)
    {
      return ParkedCars.Contains(car);
    }
  }
}
