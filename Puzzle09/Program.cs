using Puzzle09;

void Execute()
{
    var sequences = Parser.ParseSequences();

    var sum = 0;

    foreach (var sequence in sequences)
    {
        // Part 1
        //sum += sequence.GetNext();
        // Part 2
        sum += sequence.GetPrev();
    }

    Console.WriteLine($"Sum: {sum}");
}

Execute();