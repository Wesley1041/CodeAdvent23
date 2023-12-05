namespace Puzzle05
{
    public class Mapper
    {
        public string Name { get; set; }

        private List<Map> _maps;

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
            var map = _maps.Find(x => x.CheckInRange(value));

            if (map == null)
            {
                //Console.WriteLine($"Mapped {value} to itself with mapper \"{Name}\"");
                return value;
            }

            var newValue = map.MapValue(value);
            //Console.WriteLine($"Mapped {value} to {newValue} with mapper \"{Name}\"");

            return newValue;
        }
    }
}
