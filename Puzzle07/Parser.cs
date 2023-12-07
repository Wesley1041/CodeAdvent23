namespace Puzzle07
{
    public static class Parser
    {
        public static Hand? ParseHand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) return null;

            return ParseHand(input);
        }

        public static Hand ParseHand(string input)
        {
            var sections = input.Split(' ');

            return new Hand(
                ParseCards(sections[0]),
                int.Parse(sections[1]));
        }

        private static List<Card> ParseCards(string input)
        {
            var cards = new List<Card>();

            foreach (var symbol in input)
            {
                cards.Add(new Card(symbol));
            }

            return cards;
        }
    }
}
