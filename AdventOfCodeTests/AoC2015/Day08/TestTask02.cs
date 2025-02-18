namespace AdventOfCodeTests.AoC2015.Day08;

using AdventOfCode.AoC2015.Day08;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("\"\"")
                .Returns(4)
                .SetName("Test01");

            yield return new TestCaseData("\"abc\"")
                .Returns(4)
                .SetName("Test02");

            yield return new TestCaseData("\"aaa\\\"aaa\"")
                .Returns(6)
                .SetName("Test03");

            yield return new TestCaseData("\"\\x27\"")
                .Returns(5)
                .SetName("Test04");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(string inputString)
    {
        return Task02.RunTask(inputString);
    }
}
