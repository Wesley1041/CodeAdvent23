namespace Puzzle04
{
    public class CardProcessor
    {
        private List<Card> _cards;

        private Queue<Card> _queue;
        private int _count { get; set; }

        public CardProcessor(List<Card> cards)
        {
            _count = 0;
            _cards = cards;
            _queue = new Queue<Card>();

            foreach (var card in cards)
            {
                _queue.Enqueue(card);
            }
        }

        public int Process()
        {
            _count = 0;

            while (_queue.Count > 0)
            {
                var currentCard = _queue.Dequeue();
                var score = currentCard.GetScore2();

                for (var i = 0; i < score; i++)
                {
                    // Enqueue next card
                    var index = currentCard.Id + i;
                    if (index < _cards.Count)
                    {
                        _queue.Enqueue(_cards[index]);
                    }
                }

                _count++;
            }

            return _count;
        }
    }
}
