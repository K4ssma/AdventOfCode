namespace AdventOfCode.AoC2015.Day07.Logics.Gates;

using AdventOfCode.AoC2015.Day07.Logics.Values;

public class OrGate(IValue valueOne, IValue valueTwo, string outputWireId) : IGate
{
    public IValue ValueOne { get; init; } = valueOne;

    public IValue ValueTwo { get; init; } = valueTwo;

    public string OutputWireId { get; init; } = outputWireId;
}
