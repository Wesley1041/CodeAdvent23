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
    hands.Sort((x, y) => x.IsGreaterThan(y, true) ? 1 : -1);

    var sum = 0;

    for (int i = 0; i < hands.Count; i++)
    {
        Test(hands[i]);
        sum += hands[i].Bid * (i + 1);
    }

    Console.WriteLine($"Winnings: {sum}");
}

void Test(Hand hand)
{
    var highest = 0;
    char? highestChar = null;

    var dict = new Dictionary<char, int>();

    foreach (var card in hand.Cards)
    {
        var value = card.Value;
        if (dict.ContainsKey(value)) dict[value]++;
        else dict.Add(value, 1);
    }

    var jokers = 0;
    if (dict.ContainsKey('J'))
        jokers = dict['J'];

    var handString = "";

    foreach (var item in dict)
    {
        handString += item.Key;

        if (item.Key == 'J') continue;

        if (item.Value > highest)
        {
            highest = item.Value;
            highestChar = item.Key;
        }
    }

    var output = "";
    if (jokers < 5)
    {
        foreach (var item in handString)
        {
            output += item == 'J' ? highestChar : item;
        }
    }

    Console.WriteLine($"{output} - {hand.GetHandTypeWithJokers()}");
}

//Test();
Arrange();
Execute();

// Part 2:
// 253499509 too low
// 253626343 too high