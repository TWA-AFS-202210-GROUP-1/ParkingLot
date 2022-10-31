namespace ParkingLot
{
  public enum OperationStatus
  {
    /// <summary>
    /// Parking is successful
    /// </summary>
    ParkingSuccessful,

    /// <summary>
    /// Parking has failed because car is null or already exists in the parking lot
    /// </summary>
    ParkingFailed,

    /// <summary>
    /// Parking has failed because the parking lot has no empty slot left
    /// </summary>
    NoVacancy,

    /// <summary>
    /// Successfully removed the car from the pariking lot
    /// </summary>
    RemovingSuccessful,

    /// <summary>
    /// Removing car has failed because car is null or does not exist in the parking lot
    /// </summary>
    RemovingFailed,
  }
}
