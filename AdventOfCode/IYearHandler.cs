namespace AdventOfCode;

using Microsoft.Extensions.Configuration;

internal interface IYearHandler
{
    public Task<bool> RunYear();
}
