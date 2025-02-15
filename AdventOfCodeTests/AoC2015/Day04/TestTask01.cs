namespace AdventOfCodeTests.AoC2015.Day04;

using AdventOfCode.AoC2015.Day04;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("abcdef")
                .Returns(609043)
                .SetName("Test01");

            yield return new TestCaseData("pqrstuv")
                .Returns(1048970)
                .SetName("Test02");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(string inputString)
    {
        return Task01.RunTask(inputString);
    }
}
