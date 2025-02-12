namespace AdventOfCode;

internal interface IDoorHandler
{
    /// <summary>
    /// lets the user choose a task, runs the corresponding solution and outputs the result in the console
    /// </summary>
    /// <returns>
    /// <para><c>false</c> user entered the in the config defined exit code</para>
    /// <para><c>true</c> the result got successfully printed in the console</para>
    /// </returns>
    public Task<bool> OpenDoor(string inputString);
}