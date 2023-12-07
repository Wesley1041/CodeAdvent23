using Puzzle07;

List<Hand> hands = new List<Hand>();

void Arrange()
{
    while (true)
    {
        var hand = Parser.ParseHand();

        if (hand == null) break;

        hands.Add(hand);
    }
}

void Execute()
{
    hands.Sort((x, y) => x.IsGreaterThan(y) ? 1 : -1);

    var sum = 0;

    for (int i = 0; i < hands.Count; i++)
    {
        //Console.WriteLine($"{hands[i].GetCards()} - {hands[i].GetHandType()}");
        sum += hands[i].Bid * (i + 1);
    }

    Console.WriteLine($"Winnings: {sum}");
}

void Test()
{
    var hand = Parser.ParseHand("22699 1");

    Console.WriteLine(hand.GetHandType());
}

//Test();
Arrange();
Execute();

// 252671874 too high