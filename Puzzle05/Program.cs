using Puzzle05;

List<long> seeds = new List<long>();
List<Mapper> mappers = new List<Mapper>();

void Arrange()
{
    // Parse seeds
    var newSeeds = Parser.ParseSeeds();

    if (newSeeds == null) throw new ArgumentException("Seeds could not be parsed");

    seeds.AddRange(newSeeds);

    Console.ReadLine();

    // Parse mappers
    while (true)
    {
        var mapper = Parser.ParseMapper();

        if (mapper == null) break;

        mappers.Add(mapper);
    }

    //Console.WriteLine($"Mappers found: {mappers.Count}");
}

long MapValue(long value)
{
    foreach (var mapper in mappers)
    {
        value = mapper.MapValue(value); // should be O(1)
    }

    return value;
}

void Execute()
{
    // Map seeds to locations
    var locations = new List<long>();

    foreach (var seed in seeds)
    {
        var location = MapValue(seed);

        locations.Add(location);
        //Console.WriteLine($"Location found: {location}");
    }

    // Get lowest location
    var minValue = locations.Min();

    Console.WriteLine($"Nearest location: {minValue}");
}

void Execute2()
{
    Console.WriteLine("Start processing seeds");

    long? nearestLocation = null;

    for (var i = 0; i < seeds.Count; i += 2)
    {
        var rangeStart = seeds[i];
        var rangeEnd = rangeStart + seeds[i + 1];
        
        Console.WriteLine($"Process seed range {rangeStart}..{rangeEnd}");

        for (var seed = rangeStart; seed <= rangeEnd; seed++)
        {
            //Console.WriteLine($"Process seed {seed}");
            var location = MapValue(seed);
            if (nearestLocation == null || location < nearestLocation)
            {
                nearestLocation = location;
            }
        }
        
        Console.WriteLine($"Nearest location: {nearestLocation}");
    }
}

Arrange();
Execute2();