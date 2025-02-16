namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

using AdventOfCode.AoC2015.Day07.Logics.Values;

public class AndGate(IValue valueOne, IValue valueTwo, string outputWireId) : IGate
{
    public GateType Type { get => GateType.And; }

    public IValue ValueOne { get; init; } = valueOne;

    public IValue ValueTwo { get; init; } = valueTwo;

    public string OutputWireId { get; init; } = outputWireId;
}
