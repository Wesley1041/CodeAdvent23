using Puzzle08;

ParseResult Arrange()
{
    // Get directions
    var directions = Parser.ParseDirections();

    Console.ReadLine();

    var locations = Parser.ParseLocations();

    return new ParseResult(locations, directions);
}

void Execute()
{
    var input = Arrange();

    var executor = new PartTwo(input.Locations, input.Directions);

    // Get start locations
    var startLocations = input.Locations
        .Where(p => p.Key.EndsWith('A'))
        .Select(p => p.Value)
        .ToList();

    var steps = startLocations.Select(l => executor.DoSteps(l)).ToList();

    long sum = 1;
    foreach (var step in steps) sum *= step;

    Console.WriteLine($"Steps: {sum}");
}

Execute();