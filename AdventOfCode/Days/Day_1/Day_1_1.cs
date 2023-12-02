namespace AdventOfCode.Days.Day_1;

internal class Day_1_1 : IDailyExercise
{
    public int Day => 1;
    public int Part => 1;

    public int? ExpectedResult => 54597;

    public int Run(string input)
        => input.Split(Environment.NewLine)
            .Sum(l => int.Parse(
                l.FirstOrDefault(c => char.IsDigit(c)).ToString()
                + l.LastOrDefault(c => char.IsDigit(c)).ToString()));
}
