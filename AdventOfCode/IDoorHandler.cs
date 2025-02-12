namespace AdventOfCode;

internal interface IDoorHandler
{
    /// <summary>
    /// lets the user choose a task, runs the corresponding solution
    /// </summary>
    /// <returns>
    /// <para><c>null</c> user entered the in the config defined exit code</para>
    /// <para><c>int</c> the result of the chosen solution</para>
    /// </returns>
    public int? OpenDoor(string inputString);
}