namespace AdventOfCode;

internal interface IYearHandler
{
    /// <summary>
    /// lets the user choose a day of whichs task he wants to run the solution
    /// </summary>
    /// <returns>
    /// <para><c>null</c> the user entered the in the config defined exit code</para>
    /// <para><c>Task</c> fulfills when the solution got successfully printed to the console</para>
    /// </returns>
    public Task? RunYear();
}
