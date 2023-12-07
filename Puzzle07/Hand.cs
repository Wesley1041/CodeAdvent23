namespace Puzzle07
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public int Bid { get; set; }

        public Hand(List<Card> cards, int bid)
        {
            Cards = cards;
            Bid = bid;
        }

        public int GetHandType()
        {
            var frequencies = new Dictionary<int, int>();
            var highest = 0;

            foreach (var card in Cards)
            {
                var strength = card.Strength;

                if (frequencies.ContainsKey(strength))
                {
                    frequencies[strength]++;

                    if (frequencies[strength] > highest)
                    {
                        highest = frequencies[strength];
                    }
                } 
                else
                {
                    frequencies.Add(strength, 1);
                }
            }

            switch (highest)
            {
                case 5:
                    return 6;
                case 4:
                    return 5;
                case 3:
                    if (frequencies.Values.ToList().Contains(2)) return 4;
                    return 3;
                case 2:
                    if (HasTwoPairs(frequencies)) return 2;
                    return 1;
                case 1:
                default:
                    return 0;
            }
        }

        public bool IsGreaterThan(Hand otherHand)
        {
            var x = GetHandType();
            var y = otherHand.GetHandType();

            if (x != y) return x > y;

            for (int i = 0; i < Cards.Count; i++)
            {
                var strengthX = Cards[i].Strength;
                var strengthY = otherHand.Cards[i].Strength;

                if (strengthX != strengthY) return strengthX > strengthY;
            }

            return false;
        }

        public string GetCards()
        {
            var output = "";

            foreach (var card in Cards)
            {
                output += card.Value;
            }

            return output;
        }

        private bool HasTwoPairs(Dictionary<int, int> frequencies)
        {
            var count = 0;

            foreach (var value in frequencies.Values)
            {
                if (value == 2)
                {
                    count++;
                }

                if (count == 2) return true;
            }

            return false;
        }
    }
}
