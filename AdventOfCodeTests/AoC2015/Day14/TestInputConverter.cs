namespace AdventOfCodeTests.AoC2015.Day14;

using AdventOfCode.AoC2015.Day14;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.\r\n" +
                "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.\r\n")
                .Returns(new (uint FlightSpeed, uint FlightTime, uint RestTime)[]
                {
                    (14, 10, 127),
                    (16, 11, 162),
                })
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static (uint, uint, uint)[] Convert_ValidCases_ShouldReturnCorrectValue(string inputString)
    {
        return InputConverter.Convert(inputString).ToArray();
    }
}
