namespace AdventOfCodeTests.AoC2015.Day17;

using AdventOfCode.AoC2015.Day17;

[TestFixture]
public static class TestInputConverter
{
    public static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData(
                "20\r\n" +
                "15\r\n" +
                "10\r\n" +
                "5\r\n" +
                "5")
                .Returns(new ushort[] { 20, 15, 10, 5, 5 })
                .SetName("Test01");
        }
    }

    [TestCaseSource(nameof(TestCases))]
    public static ushort[] Convert_ValidCases_ShouldReturnCorrectValues(string inputString)
    {
        return InputConverter.Convert(inputString);
    }
}
