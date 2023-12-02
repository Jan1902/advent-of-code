namespace AdventOfCode.Days.Day_2;

internal class Day_2_1 : IDailyExercise
{
    public int Day => 2;
    public int Part => 1;
    public int? ExpectedResult => 2268;

    public int Run(string input)
    {
        var constraints = new Dictionary<Color, int>()
        {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 }
        };

        var sum = 0;

        foreach (var game in GameParser.ParseGame(input))
        {
            if (!game.Rounds.Any(r => r.ShownColors.Any(c => c.Amount > constraints[c.Color])))
                sum += game.Id;
        }

        return sum;
    }
}
