namespace Puzzle05
{
    public class Map
    {
        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long RangeLength { get; set; }

        public Map(long destinationStart, long sourceStart, long rangeLength)
        {
            DestinationStart = destinationStart; 
            SourceStart = sourceStart; 
            RangeLength = rangeLength; 
        }

        public bool CheckInRange(long value)
        {
            return value >= SourceStart && value <= SourceStart + RangeLength;
        }

        public long MapValue(long value)
        {
            if (!CheckInRange(value))
            {
                throw new InvalidOperationException("Supplied value cannot be used with this map");
            }

            return value + DestinationStart - SourceStart;
        }
    }
}
