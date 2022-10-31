using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
  public class ChooseParkingLotService
  {
    public delegate ParkingLot ChooseParkingLotDelegate(List<ParkingLot> parkingLots);

    public static ParkingLot ChooseParkingLotBasic(List<ParkingLot> parkingLots)
    {
      var chosenParkingLot = parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();

      return chosenParkingLot.Any() ? chosenParkingLot.First() : null;
    }

    public static ParkingLot ChooseParkingLotSmart(List<ParkingLot> parkingLots)
    {
      var chosenParkingLot = parkingLots.Where(parkingLot => parkingLot.EmptySlots > 0).ToList();

      return chosenParkingLot.Any()
           ? chosenParkingLot.OrderByDescending(parkingLot => parkingLot.EmptySlots).First()
           : null;
    }
  }
}
