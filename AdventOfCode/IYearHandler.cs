namespace AdventOfCode;

internal interface IYearHandler
{
    /// <summary>
    /// <para>contains all solved days of this year</para>
    /// <para>the <c>Values</c> are the DayHandlers for the day, that is defined by the <c>Key</c></para>
    /// </summary>
    public Dictionary<int, IDayHandler> AvailableDays { get; }
}
