namespace AdventOfCodeTests.AoC2015.Day07;

using AdventOfCode.AoC2015.Day07;
using AdventOfCode.AoC2015.Day07.Logics.Gates;
using AdventOfCode.AoC2015.Day07.Logics.Values;

[TestFixture]
public static class TestInputConverter
{
    [Test]
    public static void Convert_ValidCase_ShouldReturnCorrectResult()
    {
        // arrange
        string inputString =
            "123 -> x\r\n" +
            "456 -> y\r\n" +
            "x AND y -> d\r\n" +
            "x OR y -> e\r\n" +
            "x LSHIFT 2 -> f\r\n" +
            "y RSHIFT 2 -> g\r\n" +
            "NOT x -> h\r\n" +
            "NOT y -> i";

        // act
        Dictionary<string, IGate> result = InputConverter.Convert(inputString);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(8));

            Assert.That(result.ContainsKey("x"));
            Assert.That(result.ContainsKey("y"));
            Assert.That(result.ContainsKey("d"));
            Assert.That(result.ContainsKey("e"));
            Assert.That(result.ContainsKey("f"));
            Assert.That(result.ContainsKey("g"));
            Assert.That(result.ContainsKey("h"));
            Assert.That(result.ContainsKey("i"));
        });

        Assert.Multiple(() =>
        {
            Assert.That(result["x"], Is.TypeOf(typeof(ConstantGate)));
            Assert.That(result["y"], Is.TypeOf(typeof(ConstantGate)));
            Assert.That(result["d"], Is.TypeOf(typeof(AndGate)));
            Assert.That(result["e"], Is.TypeOf(typeof(OrGate)));
            Assert.That(result["f"], Is.TypeOf(typeof(LShiftGate)));
            Assert.That(result["g"], Is.TypeOf(typeof(RShiftGate)));
            Assert.That(result["h"], Is.TypeOf(typeof(NotGate)));
            Assert.That(result["i"], Is.TypeOf(typeof(NotGate)));
        });

        Assert.Multiple(() =>
        {
            Assert.That(((ConstantGate)result["x"]).Value, Is.TypeOf(typeof(ConstantValue)));

            Assert.That(((ConstantGate)result["y"]).Value, Is.TypeOf(typeof(ConstantValue)));

            Assert.That(((AndGate)result["d"]).ValueOne, Is.TypeOf(typeof(WireValue)));
            Assert.That(((AndGate)result["d"]).ValueTwo, Is.TypeOf(typeof(WireValue)));

            Assert.That(((OrGate)result["e"]).ValueOne, Is.TypeOf(typeof(WireValue)));
            Assert.That(((OrGate)result["e"]).ValueTwo, Is.TypeOf(typeof(WireValue)));

            Assert.That(((LShiftGate)result["f"]).Value, Is.TypeOf(typeof(WireValue)));
            Assert.That(((LShiftGate)result["f"]).ShiftAmount, Is.TypeOf(typeof(ConstantValue)));

            Assert.That(((RShiftGate)result["g"]).Value, Is.TypeOf(typeof(WireValue)));
            Assert.That(((RShiftGate)result["g"]).ShiftAmount, Is.TypeOf(typeof(ConstantValue)));

            Assert.That(((NotGate)result["h"]).Value, Is.TypeOf(typeof(WireValue)));

            Assert.That(((NotGate)result["i"]).Value, Is.TypeOf(typeof(WireValue)));
        });

        Assert.Multiple(() =>
        {
            Assert.That(((ConstantValue)((ConstantGate)result["x"]).Value).Value, Is.EqualTo(123));

            Assert.That(((ConstantValue)((ConstantGate)result["y"]).Value).Value, Is.EqualTo(456));

            Assert.That(((WireValue)((AndGate)result["d"]).ValueOne).WireId, Is.EqualTo("x"));
            Assert.That(((WireValue)((AndGate)result["d"]).ValueTwo).WireId, Is.EqualTo("y"));

            Assert.That(((WireValue)((OrGate)result["e"]).ValueOne).WireId, Is.EqualTo("x"));
            Assert.That(((WireValue)((OrGate)result["e"]).ValueTwo).WireId, Is.EqualTo("y"));

            Assert.That(((WireValue)((LShiftGate)result["f"]).Value).WireId, Is.EqualTo("x"));
            Assert.That(((ConstantValue)((LShiftGate)result["f"]).ShiftAmount).Value, Is.EqualTo(2));

            Assert.That(((WireValue)((RShiftGate)result["g"]).Value).WireId, Is.EqualTo("y"));
            Assert.That(((ConstantValue)((RShiftGate)result["g"]).ShiftAmount).Value, Is.EqualTo(2));

            Assert.That(((WireValue)((NotGate)result["h"]).Value).WireId, Is.EqualTo("x"));

            Assert.That(((WireValue)((NotGate)result["i"]).Value).WireId, Is.EqualTo("y"));
        });
    }
}
