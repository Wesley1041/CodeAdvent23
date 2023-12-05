namespace Puzzle05
{
    public static class Parser
    {
        public static List<long>? ParseSeeds()
        {
            var input = Console.ReadLine();

            if (input == null) return null;

            var seedsString = input.Split(": ")[1];

            var seeds = new List<long>();

            var parsedSeeds = seedsString.Split(' ');
            foreach (var seed in parsedSeeds)
            {
                seeds.Add(long.Parse(seed));
            }

            return seeds;
        }

        public static Mapper? ParseMapper()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) return null;

            var name = input.Split(' ')[0];

            var mapper = new Mapper(name);

            while (true)
            {
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) break;

                var args = input.Split(' ');
                var map = new Map(
                    long.Parse(args[0]),
                    long.Parse(args[1]),
                    long.Parse(args[2]));

                mapper.AddMap(map);
            }

            return mapper;
        }
    }
}
