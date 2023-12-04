namespace Puzzle02
{
    public class Game
    {
        public int Id;
        public List<Round> Rounds;

        public Game(int id, string roundsInput)
        {
            Id = id;
            Rounds = new List<Round>();

            ParseInput(roundsInput);
        }

        public bool IsPossible(int maxRed, int maxGreen, int maxBlue)
        {
            foreach (var round in Rounds)
            {
                if (round.RedCubes > maxRed || round.GreenCubes > maxGreen || round.BlueCubes > maxBlue)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetPower()
        {
            var minRed = 0;
            var minGreen = 0;
            var minBlue = 0;

            foreach (var round in Rounds)
            {
                minRed = Math.Max(minRed, round.RedCubes);
                minGreen = Math.Max(minGreen, round.GreenCubes);
                minBlue = Math.Max(minBlue, round.BlueCubes);
            }

            return minRed * minGreen * minBlue;
        }

        private void ParseInput(string input)
        {
            var roundsInput = input.Split("; ");
            foreach (var round in roundsInput)
            {
                ParseRound(round);
            }
        }

        private void ParseRound(string roundInput)
        {
            var round = new Round();

            var cubes = roundInput.Split(", ");
            foreach (var cube in cubes)
            {
                var values = cube.Split(' ');
                // 1st value should be a digit
                var count = int.Parse(values[0]);
                // 2nd value should be the color
                switch (values[1])
                {
                    case "red":
                        round.RedCubes = count;
                        break;
                    case "green":
                        round.GreenCubes = count;
                        break;
                    case "blue":
                        round.BlueCubes = count;
                        break;
                    default:
                        throw new ArgumentException("Invalid color input provided");
                }
            }

            Rounds.Add(round);
        }
    }
}
