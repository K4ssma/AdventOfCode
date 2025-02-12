namespace AdventOfCode.AoC2015.Door01;

internal class DoorHandler : IDoorHandler
{
    public int? OpenDoor(string inputString)
    {
        int? taskNum = UserInputUtility.ReadIntChoice(
            [], "Please enter which task you want to run.");

        if (taskNum == null)
        {
            return null;
        }

        Func<string, int> taskFunc;

        switch (taskNum.Value)
        {
            default:
            {
                throw new NotImplementedException($"task '{taskNum}' is not yet supported");
            }
        }

        return taskFunc(inputString);
    }
}
