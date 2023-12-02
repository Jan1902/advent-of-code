namespace AdventOfCode.Days.Day_1;

internal class Day_1_2 : IDailyExercise
{
    public int Day => 1;
    public int Part => 2;
    public int? ExpectedResult => 54504;

    public int Run(string input)
    {
        var spelledNumbers = new (string Text, int Number)[]
        {
            ("one", 1),
            ("two", 2),
            ("three", 3),
            ("four", 4),
            ("five", 5),
            ("six", 6),
            ("seven", 7),
            ("eight", 8),
            ("nine", 9)
        };

        var sum = 0;

        foreach (var line in input.Split(Environment.NewLine))
        {
            var numbers = new List<(int Number, int Position)>();

            var firstNrDigit = line.FirstOrDefault(char.IsDigit);
            numbers.Add((int.Parse(firstNrDigit.ToString()), line.IndexOf(firstNrDigit)));

            var lastNrDigit = line.LastOrDefault(char.IsDigit);
            numbers.Add((int.Parse(lastNrDigit.ToString()), line.LastIndexOf(lastNrDigit)));

            foreach (var (text, number) in spelledNumbers)
            {
                var firstIndex = line.IndexOf(text);
                if (firstIndex != -1)
                    numbers.Add((number, firstIndex));

                var lastIndex = line.LastIndexOf(text);
                if (lastIndex != -1)
                    numbers.Add((number, lastIndex));
            }

            var firstNr = numbers.FirstOrDefault(n => n.Position == numbers.Min(nr => nr.Position)).Number;
            var lastNr = numbers.FirstOrDefault(n => n.Position == numbers.Max(nr => nr.Position)).Number;
            sum += int.Parse(firstNr.ToString() + lastNr.ToString());
        }

        return sum;
    }
}
