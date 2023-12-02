namespace AdventOfCode.Days;

public interface IDailyExercise
{
    int Run(string input);
    int Day { get; }
    int Part { get; }
    int? ExpectedResult { get => null; }
}