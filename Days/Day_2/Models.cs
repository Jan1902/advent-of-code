namespace AdventOfCode.Days.Day_2;

internal record Game(int Id, Round[] Rounds);
internal record Round(PulledColor[] ShownColors);
internal record PulledColor(Color Color, int Amount);
internal enum Color
{
    Red,
    Green,
    Blue
}
