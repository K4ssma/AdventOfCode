namespace AdventOfCode.AoC2015.Day07;

using AdventOfCode.AoC2015.Day07.Logics.Gates;
using AdventOfCode.AoC2015.Day07.Logics.Values;

internal static class Task01
{
    public static int RunTask(Dictionary<string, IGate> gates, string wireId)
    {
        Dictionary<string, ushort> values = [];
        Stack<string> needToSolveWireIds = new();

        needToSolveWireIds.Push(wireId);

        while (needToSolveWireIds.Count > 0)
        {
            string currId = needToSolveWireIds.Peek();

            if (values.ContainsKey(currId))
            {
                needToSolveWireIds.Pop();
                continue;
            }

            IGate gate = gates[currId];

            IValue[] inputValueTypes;

            if (gate is ConstantGate constGate)
            {
                inputValueTypes = [constGate.Value];
            }
            else if (gate is AndGate andGate)
            {
                inputValueTypes = [andGate.ValueOne, andGate.ValueTwo];
            }
            else if (gate is OrGate orGate)
            {
                inputValueTypes = [orGate.ValueOne, orGate.ValueTwo];
            }
            else if (gate is LShiftGate lShiftGate)
            {
                inputValueTypes = [lShiftGate.Value, lShiftGate.ShiftAmount];
            }
            else if (gate is RShiftGate rShiftGate)
            {
                inputValueTypes = [rShiftGate.Value, rShiftGate.ShiftAmount];
            }
            else if (gate is NotGate notGate)
            {
                inputValueTypes = [notGate.Value];
            }
            else
            {
                throw new NotSupportedException($"{nameof(IGate)} '{gate}' is not supported");
            }

            bool inputsAreResolved = true;
            ushort[] resolvedInputs = new ushort[inputValueTypes.Length];

            for (int i = 0; i < inputValueTypes.Length; i++)
            {
                if (inputValueTypes[i] is ConstantValue constValue)
                {
                    resolvedInputs[i] = constValue.Value;
                }
                else if (inputValueTypes[i] is WireValue wireValue)
                {
                    if (!values.TryGetValue(wireValue.WireId, out resolvedInputs[i]))
                    {
                        inputsAreResolved = false;
                        needToSolveWireIds.Push(wireValue.WireId);
                    }
                }
                else
                {
                    throw new NotSupportedException($"{nameof(IValue)} '{inputValueTypes[i]}' is not supported");
                }
            }

            if (!inputsAreResolved)
            {
                continue;
            }

            ushort result;

            if (gate is ConstantGate)
            {
                result = resolvedInputs[0];
            }
            else if (gate is AndGate)
            {
                result = (ushort)(resolvedInputs[0] & resolvedInputs[1]);
            }
            else if (gate is OrGate)
            {
                result = (ushort)(resolvedInputs[0] | resolvedInputs[1]);
            }
            else if (gate is LShiftGate)
            {
                result = (ushort)(resolvedInputs[0] << resolvedInputs[1]);
            }
            else if (gate is RShiftGate)
            {
                result = (ushort)(resolvedInputs[0] >> resolvedInputs[1]);
            }
            else if (gate is NotGate)
            {
                result = (ushort)(~resolvedInputs[0]);
            }
            else
            {
                throw new NotSupportedException($"{nameof(IGate)} '{gate}' is not supported");
            }

            values.Add(gate.OutputWireId, result);
            needToSolveWireIds.Pop();
        }

        return values[wireId];
    }
}
