namespace AdventOfCode;

internal interface IDoorHandler
{
    public Task<int>? OpenDoor();
}