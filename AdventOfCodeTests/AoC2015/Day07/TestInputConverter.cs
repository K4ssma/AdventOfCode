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
        IGate[] result = InputConverter.Convert(inputString);

        // assert
        Assert.That(result, Has.Length.EqualTo(8));

        Assert.Multiple(() =>
        {
            Assert.That(result[0].OutputWireId, Is.EqualTo("x"));
            Assert.That(result[0].Type, Is.EqualTo(GateType.Constant));

            Assert.That(result[1].OutputWireId, Is.EqualTo("y"));
            Assert.That(result[1].Type, Is.EqualTo(GateType.Constant));

            Assert.That(result[2].OutputWireId, Is.EqualTo("d"));
            Assert.That(result[2].Type, Is.EqualTo(GateType.And));

            Assert.That(result[3].OutputWireId, Is.EqualTo("e"));
            Assert.That(result[3].Type, Is.EqualTo(GateType.Or));

            Assert.That(result[4].OutputWireId, Is.EqualTo("f"));
            Assert.That(result[4].Type, Is.EqualTo(GateType.LShift));

            Assert.That(result[5].OutputWireId, Is.EqualTo("g"));
            Assert.That(result[5].Type, Is.EqualTo(GateType.RShift));

            Assert.That(result[6].OutputWireId, Is.EqualTo("h"));
            Assert.That(result[6].Type, Is.EqualTo(GateType.Not));

            Assert.That(result[7].OutputWireId, Is.EqualTo("i"));
            Assert.That(result[7].Type, Is.EqualTo(GateType.Not));
        });

        Assert.Multiple(() =>
        {
            Assert.That(((ConstantGate)result[0]).Value.Type, Is.EqualTo(ValueType.Constant));

            Assert.That(((ConstantGate)result[1]).Value.Type, Is.EqualTo(ValueType.Constant));

            Assert.That(((AndGate)result[2]).ValueOne.Type, Is.EqualTo(ValueType.Wire));
            Assert.That(((AndGate)result[2]).ValueTwo.Type, Is.EqualTo(ValueType.Wire));

            Assert.That(((OrGate)result[3]).ValueOne.Type, Is.EqualTo(ValueType.Wire));
            Assert.That(((OrGate)result[3]).ValueTwo.Type, Is.EqualTo(ValueType.Wire));

            Assert.That(((LShiftGate)result[4]).Value.Type, Is.EqualTo(ValueType.Wire));
            Assert.That(((LShiftGate)result[4]).ShiftAmount.Type, Is.EqualTo(ValueType.Constant));

            Assert.That(((RShiftGate)result[5]).Value.Type, Is.EqualTo(ValueType.Wire));
            Assert.That(((RShiftGate)result[5]).ShiftAmount.Type, Is.EqualTo(ValueType.Constant));

            Assert.That(((NotGate)result[6]).Value.Type, Is.EqualTo(ValueType.Wire));

            Assert.That(((NotGate)result[7]).Value.Type, Is.EqualTo(ValueType.Wire));
        });

        Assert.Multiple(() =>
        {
            Assert.That(((ConstantValue)((ConstantGate)result[0]).Value).Value, Is.EqualTo(123));

            Assert.That(((ConstantValue)((ConstantGate)result[1]).Value).Value, Is.EqualTo(456));

            Assert.That(((WireValue)((AndGate)result[2]).ValueOne).WireId, Is.EqualTo("x"));
            Assert.That(((WireValue)((AndGate)result[2]).ValueTwo).WireId, Is.EqualTo("y"));

            Assert.That(((WireValue)((OrGate)result[3]).ValueOne).WireId, Is.EqualTo("x"));
            Assert.That(((WireValue)((OrGate)result[3]).ValueTwo).WireId, Is.EqualTo("y"));

            Assert.That(((WireValue)((LShiftGate)result[4]).Value).WireId, Is.EqualTo("x"));
            Assert.That(((ConstantValue)((LShiftGate)result[4]).ShiftAmount).Value, Is.EqualTo(2));

            Assert.That(((WireValue)((RShiftGate)result[5]).Value).WireId, Is.EqualTo("y"));
            Assert.That(((ConstantValue)((RShiftGate)result[5]).ShiftAmount).Value, Is.EqualTo(2));

            Assert.That(((WireValue)((NotGate)result[6]).Value).WireId, Is.EqualTo("x"));

            Assert.That(((WireValue)((NotGate)result[7]).Value).WireId, Is.EqualTo("y"));
        });
    }
}
