using Puzzle02;

List<Game> _items = new List<Game>();

var maxRed = 12;
var maxGreen = 13;
var maxBlue = 14;

Game? TryReadLine()
{
    string? input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        return null;
    }

    // Get round
    var idContentPair = input.Split(": ").ToList();
    var id = int.Parse(
        idContentPair.First().Split(' ')[1]);

    return new Game(id, idContentPair[1]);
}

void Execute()
{
    // Loop through input
    while (true)
    {
        var item = TryReadLine();

        if (item == null) break;

        _items.Add(item);
    }

    var count = 0;

    foreach (var item in _items)
    {
        count += item.GetPower();
    }

    Console.WriteLine(count);
}

Execute();