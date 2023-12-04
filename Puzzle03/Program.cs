using Puzzle03;

List<string> ReadLines()
{
    List<string> lines = new List<string>();

    while (true)
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            return lines;
        }

        lines.Add(input);
    }
}

void Execute1()
{
    // Loop through input
    var lines = ReadLines();

    // Parse input
    Grid grid = new Grid(lines);

    // Get sum
    var sum = grid.GetSum();

    Console.WriteLine(sum);
}

void Execute2()
{
    // Loop through input
    var lines = ReadLines();

    // Parse input
    Grid grid = new Grid(lines);

    // Get sum
    var calculator = new GearCalculator(grid);
    var sum = calculator.GetGearRatioSum();

    Console.WriteLine(sum);
}

Execute2();