namespace AdventOfCodeTests.AoC2015.Day01;

using AdventOfCode.AoC2015.Day01;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCasesTask02
    {
        get
        {
            yield return new TestCaseData(")").Returns(1).SetName("Test01");
            yield return new TestCaseData("()())").Returns(5).SetName("Test02");
        }
    }

    [TestCaseSource(nameof(TestCasesTask02))]
    public static int Task02_ValidCases_ShouldReturnCorrectNum(string inputString)
    {
        return Task02.RunTask(inputString);
    }
}
