namespace AdventOfCode.AoC2015.Day14;

internal static class Task02
{
    public static int RunTask(
        (uint Speed, uint FlightTime, uint RestTime)[] reindeersTimes,
        uint measuringTime)
    {
        if (reindeersTimes.Length == 0)
        {
            throw new ArgumentException("the provided array must have at least one element");
        }

        uint[] points = new uint[reindeersTimes.Length];
        uint[] distances = new uint[reindeersTimes.Length];
        uint[] timers = new uint[reindeersTimes.Length];
        bool[] isResting = new bool[reindeersTimes.Length];

        for (int i = 0; i < reindeersTimes.Length; i++)
        {
            timers[i] = reindeersTimes[i].FlightTime;
        }

        for (int i = 0; i < measuringTime; i++)
        {
            List<int> maxDistanceIndeces = [];
            uint maxDistance = 0;

            for (int j = 0; j < reindeersTimes.Length; j++)
            {
                if (!isResting[j])
                {
                    distances[j] += reindeersTimes[j].Speed;
                }

                timers[j]--;

                if (timers[j] == 0)
                {
                    timers[j] = isResting[j]
                        ? reindeersTimes[j].FlightTime
                        : reindeersTimes[j].RestTime;

                    isResting[j] = !isResting[j];
                }

                if (distances[j] < maxDistance)
                {
                    continue;
                }

                if (distances[j] == maxDistance)
                {
                    maxDistanceIndeces.Add(j);
                    continue;
                }

                maxDistanceIndeces = [];
                maxDistanceIndeces.Add(j);
                maxDistance = distances[j];
            }

            foreach (int index in maxDistanceIndeces)
            {
                points[index]++;
            }
        }

        return (int)points.Max();
    }
}
