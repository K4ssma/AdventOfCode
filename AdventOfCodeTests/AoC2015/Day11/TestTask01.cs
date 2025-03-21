namespace AdventOfCodeTests.AoC2015.Day11;

using AdventOfCode.AoC2015.Day11;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("abcdefgh").Returns("abcdffaa").SetName("Test01");

            yield return new TestCaseData("ghijklmn").Returns("ghjaabcc").SetName("Test02");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static string RunTask_ValidCases_ShouldReturnValidPassword(string previousPassword)
    {
        return Task01.RunTask(previousPassword);
    }
}
