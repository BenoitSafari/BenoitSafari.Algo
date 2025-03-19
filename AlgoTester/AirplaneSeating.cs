namespace AlgoTester;

public static class AirplaneSeating
{
    public static Seat AssignFirstAvailableSeat(List<Seat> seats, Passenger passenger)
    {
        // TODO: Implement assigning the first available seat
        throw new NotImplementedException();
    }

    public static Seat AssignSeatByPreferences(List<Seat> seats, Passenger passenger)
    {
        // TODO: Implement assigning seat based on passenger preferences
        throw new NotImplementedException();
    }

    public static List<(Passenger passenger, Seat seat)> OptimizeSeating(
        List<Seat> seats,
        List<Passenger> passengers
    )
    {
        // TODO: Implement seat allocation optimization
        throw new NotImplementedException();
    }
}

public enum SeatType
{
    Window,
    Aisle,
    Middle,
}

public class Passenger(string name, List<SeatType> preferences, List<string>? groupMembers = null)
{
    public string Name { get; set; } = name;
    public List<SeatType> Preferences { get; set; } = preferences;
    public List<string> GroupMembers { get; set; } = groupMembers ?? new List<string>();
}

public class Seat(int number, SeatType type)
{
    public int Number { get; set; } = number;
    public SeatType Type { get; set; } = type;
    public bool IsOccupied { get; set; } = false;
    public required Passenger Passenger { get; set; }
}
