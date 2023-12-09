namespace Puzzle09
{
    public class Sequence
    {
        public List<int> List { get; set; }
        public Sequence? Increments { get; set; }

        public Sequence(List<int> list)
        {
            List = list;

            GetIncrements();
        }

        public int GetNext()
        {
            if (Increments == null) return List.Last();

            return List.Last() + Increments.GetNext();
        }

        public int GetPrev()
        {
            if (Increments == null) return List.First();

            return List.First() - Increments.GetPrev();
        }

        private void GetIncrements()
        {
            // Check if any value is not 0 before proceeding
            if (AreAllZeros() || List.Count == 1) return; 

            var increments = new List<int>();

            for (int i = 0; i < List.Count - 1; i++)
            {
                increments.Add(List[i + 1] - List[i]);
            }

            Increments = new Sequence(increments);
        }

        private bool AreAllZeros()
        {
            foreach (var value in List)
            {
                if (value != 0) return false;
            }

            return true;
        }

    }
}
