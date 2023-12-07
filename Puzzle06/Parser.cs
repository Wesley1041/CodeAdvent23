namespace Puzzle06;

public static class Parser
{
    public static List<Race> ParseRaces()
    {
        var timesInput = ParseLineList();
        var distancesInput = ParseLineList();

        if (timesInput.Count != distancesInput.Count) throw new ArgumentException("Could not parse races");

        return timesInput
            .Select((time, index) => new Race(time, distancesInput[index]))
            .ToList();
    }

    public static Race ParseOneRace()
    {
        var time = ParseNumber();
        var distance = ParseNumber();

        return new Race(time, distance);
    }

    private static List<int> ParseLineList()
    {
        var input = Console.ReadLine();

        if (input == null) throw new ArgumentException("Could not parse row");
        
        return input
            .Split(": ")[1]
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(int.Parse)
            .ToList();
    }

    private static long ParseNumber()
    {
        var input = Console.ReadLine();

        if (input == null) throw new ArgumentException("Could not parse row");

        var digits = input
            .Split(": ")[1]
            .Where(char.IsDigit);

        var number = string.Concat(digits);

        return long.Parse(number);
    }
}