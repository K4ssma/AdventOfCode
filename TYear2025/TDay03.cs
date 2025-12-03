namespace Kassma.AdventOfCode.TYears.TYear2025;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Moq;

/// <summary>
///     Unit Tests for <see cref="Day03"/> class.
/// </summary>
[TestFixture]
internal sealed class TDay03
{
    private const string TestInput =
        "987654321111111\r\n" +
        "811111111111119\r\n" +
        "234234234234278\r\n" +
        "818181911112111";

    /// <summary>
    ///     Unit Test for <see cref="Day03.SolvePart01(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart01()
    {
        var progressMock = new Mock<Progress<ProgressStatus>>();
        var aocDay03 = new Day03();

        var result = int.Parse(aocDay03.SolvePart01(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(357));
    }

    /// <summary>
    ///     Unit Test for <see cref="Day03.SolvePart02(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart02()
    {
        var progressMock = new Mock<Progress<ProgressStatus>>();
        var aocDay03 = new Day03();

        var result = ulong.Parse(aocDay03.SolvePart02(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(3121910778619));
    }
}
