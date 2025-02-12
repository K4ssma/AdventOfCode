namespace AdventOfCode;

internal interface IYearHandler
{
    /// <summary>
    /// lets the user choose a day of whichs task he wants to run the solution
    /// </summary>
    /// <returns>
    /// <para><c>null</c> the user entered the in the config defined exit code</para>
    /// <para><c>int</c> the result of the chosen solution</para>
    /// </returns>
    public Task<int?> RunYear();
}
