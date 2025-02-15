namespace AdventOfCode;

public interface IDoorHandler
{
    /// <summary>
    /// the number of the solved task and it's corresponding solving function
    /// </summary>
    public Dictionary<int, Func<string, int>> AvailableTasks { get; }
}
