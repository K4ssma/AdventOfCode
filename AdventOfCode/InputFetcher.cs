namespace AdventOfCode;

internal static class InputFetcher
{
    public static async Task<string> FetchInput(int year, int door)
    {
        string sessionCookie = Config.Instance["SessionCookie"]
            ?? throw new ArgumentException("'SessionCookie' entry in the config is empty");

        string url = Config.Instance["AdventOfCodeUrl"]
            ?? throw new ArgumentException("'AdventOfCodeUrl' entry in the config is empty");

        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");

        return await client.GetStringAsync(url + $"/{year}/day/{door}/input");
    }
}
