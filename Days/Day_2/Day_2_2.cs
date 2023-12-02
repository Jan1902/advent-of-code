namespace AdventOfCode.Days.Day_2;

internal class Day_2_2 : IDailyExercise
{
    public int Day => 2;
    public int Part => 2;
    public int? ExpectedResult => 63542;

    public int Run(string input)
    {
        var sum = 0;

        foreach (var game in GameParser.ParseGame(input))
        {
            var minColors = Enum.GetValues<Color>().Select(cl => game.Rounds.Max(r => r.ShownColors.FirstOrDefault(c => c.Color == cl)?.Amount ?? 0));
            var power = minColors.ElementAt(0) * minColors.ElementAt(1) * minColors.ElementAt(2);
            sum += power;
        }

        return sum;
    }
}
