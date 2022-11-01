using System;

namespace ParkingLotSystem
{
    public class FetchCarResponse<T>
    {
        public FetchCarResponse(T car, string fetchMsg)
        {
            this.FetchMsg = fetchMsg;
            this.Car = car;
        }

        public string FetchMsg { get; set; }
        public T Car { get; set; }
    }
}