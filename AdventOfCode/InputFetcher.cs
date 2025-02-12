namespace AdventOfCode;

internal static class InputFetcher
{
    /// <summary>
    /// fetches the input string from the official Advent of Code website using the in the config defined url and
    /// session cookie
    /// </summary>
    /// <param name="year">
    /// the year of the input that should get fetched
    /// </param>
    /// <param name="door">
    /// the day ofthe input that should get fetched
    /// </param>
    /// <returns>
    /// <para><c>null</c> the user entered the in the config defined exit code</para>
    /// <para><c>Task</c> gets fulfilled when the input got successfully fetched and contains the input</para>
    /// </returns>
    /// <exception cref="ArgumentException">
    /// either the 'SessionCookie' or the 'AdventOfCode' config entry is empty
    /// </exception>
    public static async Task<string> FetchInput(int year, int door)
    {
        string sessionCookie = Config.Instance["SessionCookie"]
            ?? throw new ArgumentException("'SessionCookie' entry in the config is empty");

        string url = Config.Instance["AppSettings:AdventOfCodeUrl"]
            ?? throw new ArgumentException("'AdventOfCodeUrl' entry in the config is empty");

        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");

        return await client.GetStringAsync(url + $"/{year}/day/{door}/input");
    }
}
