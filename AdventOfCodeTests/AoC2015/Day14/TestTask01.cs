namespace AdventOfCodeTests.AoC2015.Day14;

using AdventOfCode.AoC2015.Day14;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                new (uint FlightSpeed, uint FlightTime, uint RestTime)[]
                {
                    (14, 10, 127),
                    (16, 11, 162),
                },
                1000u)
                .Returns(1120)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnMaxDistance(
        IEnumerable<(uint FlightSpeed, uint FlightTime, uint RestTime)> reindeerTimes,
        uint measuringTime)
    {
        return Task01.RunTask(reindeerTimes, measuringTime);
    }
}
