namespace AdventOfCode.AoC2015.Door05;

internal class DoorHandler : IDoorHandler
{
    public int? OpenDoor(string inputString)
    {
        int? taskNum = UserInputUtility.ReadIntChoice(
            [], "Please enter the number of the task you would like to run.");

        if (taskNum == null)
        {
            return null;
        }

        Func<string, int> taskFunc;

        switch (taskNum)
        {
            default:
            {
                throw new NotImplementedException($"task with number {taskNum} is not yet supported");
            }
        }

        return taskFunc(inputString);
    }
}
