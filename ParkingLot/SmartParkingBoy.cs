using System.Collections.Generic;
using static ParkingLot.ChooseParkingLotService;

namespace ParkingLot
{
  public class SmartParkingBoy : ParkingBoy
  {
    public SmartParkingBoy(List<ParkingLot> parkingLots, ChooseParkingLotDelegate chooseParkingLot) : base(parkingLots, chooseParkingLot)
    {
    }
  }
}
