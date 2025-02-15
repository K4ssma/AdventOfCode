namespace AdventOfCodeTests.AoC2015.Day03;

using AdventOfCode.AoC2015.Day03;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("^v")
                .Returns(3)
                .SetName("Test01");

            yield return new TestCaseData("^>v<")
                .Returns(3)
                .SetName("Test02");

            yield return new TestCaseData("^v^v^v^v^v")
                .Returns(11)
                .SetName("Test03");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(string inputString)
    {
        return Task02.RunTask(inputString);
    }
}
