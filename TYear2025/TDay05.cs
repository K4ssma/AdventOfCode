namespace Kassma.AdventOfCode.TYears.TYear2025;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Moq;

/// <summary>
///     Unit Tests for <see cref="Day05"/> class.
/// </summary>
[TestFixture]
internal sealed class TDay05
{
    private const string TestInput =
        "3-5\r\n" +
        "10-14\r\n" +
        "16-20\r\n" +
        "12-18\r\n" +
        "\r\n" +
        "1\r\n" +
        "5\r\n" +
        "8\r\n" +
        "11\r\n" +
        "17\r\n" +
        "32";

    /// <summary>
    ///     Unit Test for <see cref="Day05.SolvePart01(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart01()
    {
        var progressMock = new Mock<Progress<ProgressStatus>>();
        var aocDay05 = new Day05();

        var result = int.Parse(aocDay05.SolvePart01(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(3));
    }

    /// <summary>
    ///     Unit Test for <see cref="Day05.SolvePart02(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart02()
    {
        var progressMock = new Mock<Progress<ProgressStatus>>();
        var aocDay05 = new Day05();

        var result = ulong.Parse(aocDay05.SolvePart02(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(14));
    }
}
