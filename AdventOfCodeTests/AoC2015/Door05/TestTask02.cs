namespace AdventOfCodeTests.AoC2015.Door05;

using AdventOfCode.AoC2015.Door05;

[TestFixture]
public static class TestTask02
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData((object)(new string[] { "qjhvhtzxzqqjkmpb" }))
                .Returns(1)
                .SetName("Test01");

            yield return new TestCaseData((object)(new string[] { "xxyxx" }))
                .Returns(1)
                .SetName("Test02");

            yield return new TestCaseData((object)(new string[] { "uurcxstgmygtbstg" }))
                .Returns(0)
                .SetName("Test03");

            yield return new TestCaseData((object)(new string[] { "ieodomkazucvgmuy" }))
                .Returns(0)
                .SetName("Test04");

            yield return new TestCaseData((object)(new string[] { "aaa" }))
                .Returns(0)
                .SetName("Test05");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(string[] inputStrings)
    {
        return Task02.RunTask(inputStrings);
    }
}
