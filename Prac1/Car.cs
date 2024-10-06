public class Car
{
    private readonly ParkingLot parkingLot;
    private readonly string carName;
    private readonly int parkingTime;

    public string CarName { get => carName; }
    public int ParkingTime { get => parkingTime; }

    public Car(ParkingLot parkingLot, string carName, int parkTime)
    {
        this.parkingLot = parkingLot;
        this.carName = carName;
        parkingTime = parkTime;
    }

    public async Task RunAsync()
    {
        await parkingLot.ParkCarAsync(this);
    }
}