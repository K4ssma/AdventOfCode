namespace Kassma.AdventOfCode.TYears.TYear2025;

using System.Text.RegularExpressions;
using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Moq;

/// <summary>
///     Unit Tests for the <see cref="Day01"/> class.
/// </summary>
[TestFixture]
internal sealed class TDay01
{
    private const string TestInput =
        "L68\r\n" +
        "L30\r\n" +
        "R48\r\n" +
        "L5\r\n" +
        "R60\r\n" +
        "L55\r\n" +
        "L1\r\n" +
        "L99\r\n" +
        "R14\r\n" +
        "L82";

    /// <summary>
    ///     Unit Test for the <see cref="Day01.SolvePart01(IProgress{ProgressStatus}, string)"/> method.
    /// </summary>
    [Test]
    public void TSolvePart01()
    {
        var progressMock = new Mock<IProgress<ProgressStatus>>();
        var day01Solver = new Day01();

        var result = day01Solver.SolvePart01(progressMock.Object, TestInput);
        var parsedResult = int.Parse(Regex.Match(result, @"\d").Value);

        Assert.That(parsedResult, Is.EqualTo(3));
    }
}
