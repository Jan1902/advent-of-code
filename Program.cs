using AdventOfCode.Days;
using System.Reflection;

Console.WriteLine("Welcome to Advent of Code!");
Console.WriteLine("--------------------------");

var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsAssignableTo(typeof(IDailyExercise)) && t != typeof(IDailyExercise));

var days = types.Select(Activator.CreateInstance).Cast<IDailyExercise>()
    ?? throw new Exception("Error setting up days");

var httpClient = new HttpClient();

while (true)
{
    Console.WriteLine();

    Console.Write($"Select a day [{days.Select(d => d.Day).Min()}-{days.Select(d => d.Day).Max()}]: ");

    var dayInput = Console.ReadLine();
    if (!int.TryParse(dayInput, out int dayIndex))
        continue;

    if (dayIndex > days.Max(d => d.Day))
        continue;

    var dayParts = days.Where(d => d.Day == dayIndex);

    Console.Write($"Select a part [1-{dayParts.Count()}]: ");

    var partInput = Console.ReadLine();
    if (!int.TryParse(partInput, out int partIndex))
        continue;

    if (partIndex > dayParts.Max(d => d.Part))
        continue;

    //var inputText = await httpClient.GetStringAsync($"https://adventofcode.com/2023/day/{dayIndex}/input");

    var inputText = File.ReadAllText($"Days/Day_{dayIndex}/Input.txt");

    var result = dayParts.FirstOrDefault(d => d.Part == partIndex)?.Run(inputText);
    Console.WriteLine($"Result: {result}");
}