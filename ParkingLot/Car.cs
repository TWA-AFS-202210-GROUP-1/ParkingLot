using System;

namespace ParkingLot
{
  public class Car
  {
    private readonly Guid id;

    public Car(string name)
    {
      id = Guid.NewGuid();
      Name = name;
    }

    public string Name { get; private set; }

    public override string ToString()
    {
      return $"{Name}: {id}";
    }
  }
}