namespace AdventOfCode.AoC2015;

using System.Threading.Tasks;

public class Year2015Handler : IYearHandler
{
    public async Task<bool> RunYear()
    {
        int? doorNum = UserInputUtility.ReadIntChoice(
            [], "Please enter the number of the day of the task you want to run");

        if (doorNum == null)
        {
            return false;
        }

        IDoorHandler doorHandler;

        switch (doorNum)
        {
            default:
            {
                throw new ArgumentException($"day number '{doorNum}' is not yet supported");
            }
        }

        string inputString = await InputFetcher.FetchInput(2015, doorNum.Value);

        return await doorHandler.OpenDoor(inputString);
    }
}
