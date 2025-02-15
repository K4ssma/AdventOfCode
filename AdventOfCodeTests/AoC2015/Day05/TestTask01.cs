namespace AdventOfCodeTests.AoC2015.Day05;

using AdventOfCode.AoC2015.Day05;

[TestFixture]
public static class TestTask01
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData((object)(new string[] { "ugknbfddgicrmopn" }))
                .Returns(1)
                .SetName("Test01");

            yield return new TestCaseData((object)(new string[] { "aaa" }))
                .Returns(1)
                .SetName("Test02");

            yield return new TestCaseData((object)(new string[] { "jchzalrnumimnmhp" }))
                .Returns(0)
                .SetName("Test03");

            yield return new TestCaseData((object)(new string[] { "haegwjzuvuyypxyu" }))
                .Returns(0)
                .SetName("Test04");

            yield return new TestCaseData((object)(new string[] { "dvszwmarrgswjxmb" }))
                .Returns(0)
                .SetName("Test05");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static int RunTask_ValidCases_ShouldReturnCorrectInt(string[] inputStrings)
    {
        return Task01.RunTask(inputStrings);
    }
}
