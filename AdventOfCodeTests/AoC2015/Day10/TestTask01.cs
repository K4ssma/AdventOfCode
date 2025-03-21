namespace AdventOfCodeTests.AoC2015.Day10;

using AdventOfCode.AoC2015.Day10;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("1", 5)
                .Returns(6)
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectValue(string inputString, int iterationCount)
    {
        return Task01.RunTask(inputString, iterationCount);
    }
}
