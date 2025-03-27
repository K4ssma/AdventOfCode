namespace AdventOfCode.AoC2015.Day14;

internal static class Task01
{
    public static int RunTask(
        IEnumerable<(uint FlightSpeed, uint FlightDuration, uint RestDuration)> reindeerTimes,
        uint measuringTime)
    {
        uint maxDistance = 0;

        foreach ((uint FlightSpeed, uint FlightDuration, uint RestDuration) reindeer in reindeerTimes)
        {
            uint cycleDuration = reindeer.FlightDuration + reindeer.RestDuration;
            uint completedCycles = measuringTime / cycleDuration;

            uint remainingTime = measuringTime - (completedCycles * cycleDuration);

            uint distance = (completedCycles * reindeer.FlightDuration * reindeer.FlightSpeed)
              + (Math.Min(remainingTime, reindeer.FlightDuration) * reindeer.FlightSpeed);

            maxDistance = Math.Max(maxDistance, distance);
        }

        return (int)maxDistance;
    }
}
