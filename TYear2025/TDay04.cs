namespace Kassma.AdventOfCode.TYears.TYear2025;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Moq;

/// <summary>
///     Unit Tests for <see cref="Day04"/> class.
/// </summary>
[TestFixture]
internal sealed class TDay04
{
    private const string TestInput =
        "..@@.@@@@.\r\n" +
        "@@@.@.@.@@\r\n" +
        "@@@@@.@.@@\r\n" +
        "@.@@@@..@.\r\n" +
        "@@.@@@@.@@\r\n" +
        ".@@@@@@@.@\r\n" +
        ".@.@.@.@@@\r\n" +
        "@.@@@.@@@@\r\n" +
        ".@@@@@@@@.\r\n" +
        "@.@.@@@.@.";

    /// <summary>
    ///     Unit Test for <see cref="Day04.SolvePart01(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart01()
    {
        var progressMock = new Mock<Progress<ProgressStatus>>();
        var aocDay04 = new Day04();

        var result = int.Parse(aocDay04.SolvePart01(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(13));
    }
}
