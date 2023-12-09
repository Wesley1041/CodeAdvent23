namespace Puzzle08
{
    public class LoopResult
    {
        public int LoopLength { get; set; }
        public List<int> Steps { get; set; }

        public LoopResult(int length, List<int> steps)
        {
            LoopLength = length;
            Steps = steps;
        }
    }
}
