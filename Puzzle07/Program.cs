using Puzzle07;

List<Hand> hands = new List<Hand>();
List<string> output = new List<string>();

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
    // Sort
    for (int i = 0; i < hands.Count; i++)
    {
        var hand = hands[i];
        var j = i - 1;
        while (j >= 0 && hands[j].IsGreaterThan(hand, true))
        {
            hands[j + 1] = hands[j];
            j--;
        }
        hands[j + 1] = hand;
    }
    //hands.Sort((x, y) => x.IsGreaterThan(y, true) ? 1 : -1);

    var sum = 0;

    for (int i = 0; i < hands.Count; i++)
    {
        Test(hands[i], i);
        sum += hands[i].Bid * (i + 1);
    }

    Console.WriteLine($"Winnings: {sum}");
}

void Test(Hand hand, int index)
{
    var cards = hand.GetCards();
    Console.WriteLine($"{cards} - {hand.GetHandTypeWithJokers()}");

    for (int i = 0; i < index; i++)
    {
        if (!hand.IsGreaterThan(hands[i], true))
            throw new Exception($"Hand {cards} is actually smaller than {hands[i].GetCards()}");
    }
}

//Test();
Arrange();
Execute();

// Part 2:
// 253499509 too low
// 253626343 too high