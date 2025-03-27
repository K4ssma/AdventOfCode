namespace AdventOfCodeTests.AoC2015.Day14;

using AdventOfCode.AoC2015.Day14;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                new (uint, uint, uint)[]
                {
                    (14, 10, 127),
                    (16, 11, 162),
                },
                1000u)
                .Returns(689)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases((uint Speed, uint FlightTime, uint RestTime)[] reindeers, uint measureTime)
    {
        return Task02.RunTask(reindeers, measureTime);
    }
}
