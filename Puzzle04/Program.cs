using Puzzle04;

List<Card> cards = new List<Card>();

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

void Arrange()
{
    // Loop through input
    var lines = ReadLines();

    // Parse input
    foreach (var line in lines)
    {
        var sections = line.Split(": ");
        var id = Helper.SmartSplit(sections[0], " ")[1];

        var card = new Card(int.Parse(id), sections[1]);
        cards.Add(card);
    }
}

void Execute()
{
    // Get sum
    var sum = 0;
    foreach (var card in cards)
    {
        sum += card.GetScore();
    }

    Console.WriteLine(sum);
}

void Execute2()
{
    var processor = new CardProcessor(cards);

    // Get sum
    var score = processor.Process();

    Console.WriteLine(score);
}

Arrange();
Execute2();