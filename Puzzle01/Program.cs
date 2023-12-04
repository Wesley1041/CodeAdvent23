using Puzzle01;

List<Callibration> _items = new List<Callibration>();

Callibration? TryReadLine()
{
    string? input = Console.ReadLine();
    
    if (string.IsNullOrEmpty(input))
    {
        return null;
    }

    return new Callibration(input);
}

void Execute()
{
    // Loop through input
    while (true)
    {
        var item = TryReadLine();

        if (item == null)
        {
            break;
        }

        _items.Add(item);
    }

    // Check input
    int sum = 0;

    foreach (var item in _items)
    {
        sum += item.GetValue();
    }

    Console.WriteLine(sum);
}

void Test()
{
    var item = TryReadLine();

    if (item == null)
    {
        return;
    }

    Console.Write(item.GetValue());
}
//Test();
Execute();