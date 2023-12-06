namespace Puzzle05
{
    public class Mapper
    {
        public string Name { get; set; }

        private readonly List<Map> _maps;

        public Mapper(string name)
        {
            Name = name;

            _maps = new List<Map>();
        }

        public void AddMap(Map map)
        {
            _maps.Add(map);
        }

        public long MapValue(long value)
        {
            foreach (var map in _maps)
            {
                if (!map.CheckInRange(value)) continue;
                
                return map.MapValue(value);
            }

            return value;
        }
    }
}
