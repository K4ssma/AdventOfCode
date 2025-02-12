namespace AdventOfCode;

internal interface IYearHandler
{
    public Task<bool> OpenDoor(string sessionCookie);
}
