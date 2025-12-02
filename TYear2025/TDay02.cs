namespace Kassma.AdventOfCode.TYears.TYear2025;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Moq;

/// <summary>
///     Unit Tests for <see cref="Day02"/> class.
/// </summary>
[TestFixture]
internal sealed class TDay02
{
    private const string TestInput =
        "11-22," +
        "95-115," +
        "998-1012," +
        "1188511880-1188511890," +
        "222220-222224," +
        "1698522-1698528," +
        "446443-446449," +
        "38593856-38593862," +
        "565653-565659," +
        "824824821-824824827," +
        "2121212118-2121212124";

    /// <summary>
    ///     Unit Test for <see cref="Day02.SolvePart01(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart01()
    {
        var progressMock = new Mock<IProgress<ProgressStatus>>();
        var aocDay02 = new Day02();

        var result = ulong.Parse(aocDay02.SolvePart01(progressMock.Object, TestInput));

        Assert.That(result, Is.EqualTo(1227775554));
    }
}
