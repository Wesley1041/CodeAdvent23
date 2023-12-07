using Puzzle06;

List<Race> races;
Race singleRace;

void Arrange()
{
    races = Parser.ParseRaces();
}

void Arrange2()
{
    singleRace = Parser.ParseOneRace();
}

void Execute()
{
    long sum = 1;

    foreach (var race in races)
    {
        sum *= race.DoRaces();
    }
    
    Console.WriteLine($"Result: {sum}");
}

void Execute2()
{
    var records = singleRace.DoRaces();

    Console.WriteLine($"Result: {records}");
}

Arrange2();
Execute2();