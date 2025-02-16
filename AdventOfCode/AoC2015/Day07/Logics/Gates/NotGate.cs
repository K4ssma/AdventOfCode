namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

using AdventOfCode.AoC2015.Day07.Logics.Values;

public class NotGate(IValue value, string outputWireId) : IGate
{
    public GateType Type { get => GateType.Not; }

    public IValue Value { get; init; } = value;

    public string OutputWireId { get; init; } = outputWireId;
}
