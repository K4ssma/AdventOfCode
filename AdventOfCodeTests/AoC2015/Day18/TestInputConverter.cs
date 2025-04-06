namespace AdventOfCodeTests.AoC2015.Day18;

using AdventOfCode.AoC2015.Day18;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                ".#.#.#\r\n" +
                "...##.\r\n" +
                "#....#\r\n" +
                "..#...\r\n" +
                "#.#..#\r\n" +
                "####..")
                .Returns(new bool[,]
                {
                    { false, true, false, true, false, true },
                    { false, false, false, true, true, false },
                    { true, false, false, false, false, true },
                    { false, false, true, false, false, false },
                    { true, false, true, false, false, true },
                    { true, true, true, true, false, false },
                })
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static bool[,] Convert_ValidCases_ShouldReturnCorrectGrid(string inputString)
    {
        return InputConverter.Convert(inputString);
    }
}
