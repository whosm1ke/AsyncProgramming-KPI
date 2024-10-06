TimeSpan time = new TimeSpan(19, 0, 0);

ParkingLot parkingLot = new ParkingLot(5, 8,time);
List<Task> tasks = new List<Task>();

Car[] cars =
{
    new(parkingLot, "Car1", 2000),
    new(parkingLot, "Car2", 1000),
    new(parkingLot, "Car3", 1500),
    new(parkingLot, "Car4", 3000),
    new(parkingLot, "Car5", 1700),
    new(parkingLot, "Car6", 900),
    new(parkingLot, "Car7", 2000),
    new(parkingLot, "Car8", 400),
    new(parkingLot, "Car9", 1900),
    new(parkingLot, "Car10", 1400)
};

Console.WriteLine("\nSimulation of day traffic\n");
parkingLot.AdjustParkingSpots(true);
foreach (Car car in cars)
{
    tasks.Add(car.RunAsync());
}

await Task.WhenAll(tasks);

Console.WriteLine("\nSimulation of night traffic\n");
tasks.Clear();
parkingLot.AdjustParkingSpots(false);

foreach (Car car in cars)
{
    tasks.Add(car.RunAsync());
}

await Task.WhenAll(tasks);
Console.WriteLine("Parking lot is closed.");