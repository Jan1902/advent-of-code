namespace AdventOfCode.Days.Day_2;

internal static class GameParser
{
    public static IEnumerable<Game> ParseGame(string input)
    {
        foreach (var line in input.Split(Environment.NewLine))
        {
            var lineParts = line.Split(": ");
            var id = int.Parse(lineParts.First().Split(" ").Last());
            var roundsTexts = lineParts.Last().Split("; ");
            var rounds = new List<Round>();

            foreach (var round in roundsTexts)
            {
                var pulledColors = new List<PulledColor>();
                var pulledColorsTexts = round.Split(", ");

                foreach (var pulledColor in pulledColorsTexts)
                {
                    var parts = pulledColor.Split(" ");
                    var amount = int.Parse(parts.First());
                    var color = Enum.Parse<Color>(parts.Last(), true);

                    pulledColors.Add(new(color, amount));
                }

                rounds.Add(new([.. pulledColors]));
            }

            yield return new(id, [.. rounds]);
        }
    }
}
