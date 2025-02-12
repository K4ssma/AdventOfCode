namespace AdventOfCode.AoC2015;

using System.Threading.Tasks;
using AdventOfCode.AoC2015.Door01;

public class Year2015Handler : IYearHandler
{
    public async Task<int?> RunYear()
    {
        int? doorNum = UserInputUtility.ReadIntChoice(
            [1], "Please enter the number of the day of the task you want to run");

        if (doorNum == null)
        {
            return null;
        }

        IDoorHandler doorHandler;

        switch (doorNum.Value)
        {
            case 1:
            {
                doorHandler = new DoorHandler();
                break;
            }

            default:
            {
                throw new NotImplementedException($"day number '{doorNum}' is not yet supported");
            }
        }

        string inputString = await InputFetcher.FetchInput(2015, doorNum.Value);

        return doorHandler.OpenDoor(inputString);
    }
}
