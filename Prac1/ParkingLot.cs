public class ParkingLot
{
    private SemaphoreSlim parkingSpots;
    private readonly int daySpots;
    private readonly int nightSpots;
    private readonly TimeSpan workingTime;

    public ParkingLot(int daySpots, int nightSpots, TimeSpan workingTime)
    {
        this.daySpots = daySpots;
        this.nightSpots = nightSpots;
        this.workingTime = workingTime;
        this.parkingSpots = new SemaphoreSlim(daySpots);
    }

    public async Task ParkCarAsync(Car car)
    {
        if (IsParkingAllowed())
        {
            await parkingSpots.WaitAsync();
            try
            {
                Console.WriteLine($"{car.CarName} has parked.");
                await Task.Delay(car.ParkingTime);
                Console.WriteLine($"{car.CarName} has left the parking lot.");
            }
            finally
            {
                parkingSpots.Release();
            }
        }
        else
        {
            Console.WriteLine($"{car.CarName} cannot park. Parking is closed.");
        }
    }

    public void AdjustParkingSpots(bool isDayTime)
    {
        int availableSpots = isDayTime ? daySpots : nightSpots;
        parkingSpots = new SemaphoreSlim(availableSpots);
        Console.WriteLine($"Adjusted parking spots to {availableSpots}");
    }

    private bool IsParkingAllowed()
    {
        return DateTime.Now.TimeOfDay < workingTime;
    }
}