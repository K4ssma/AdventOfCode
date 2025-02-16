namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

using AdventOfCode.AoC2015.Day07.Logics.Values;

public class RShiftGate(IValue value, IValue shiftAmount, string outputWireId) : IGate
{
    public GateType Type { get => GateType.RShift; }

    public IValue Value { get; init; } = value;

    public IValue ShiftAmount { get; init; } = shiftAmount;

    public string OutputWireId { get; init; } = outputWireId;
}
