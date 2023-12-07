namespace Puzzle06;

public class Race
{
    public long Time { get; set; }
    public long Distance { get; set; }

    public Race(long time, long distance)
    {
        Time = time;
        Distance = distance;
    }

    public long DoRaces()
    {
        var wins = 0;
        
        for (var time = 1; time < Time; time++)
        {
            if (DoRace(time))
            {
                wins++;
            }
        }

        return wins;
    }

    private bool DoRace(long chargeTime)
    {
        var speed = chargeTime;
        var distance = speed * (Time - chargeTime);

        return distance > Distance;
    }
}