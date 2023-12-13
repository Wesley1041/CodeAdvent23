using Helpers;

namespace Puzzle12;

public static class Parser
{
    public static ParseResult ParseInput()
    {
        var lines = BaseParser.ParseLines();
        var rows = lines.Select(l => l.Split(' ').First()).ToList();
        var sizes = lines.Select(l => ParseNumbers(l.Split(' ')[1])).ToList();

        return new ParseResult(rows, sizes);
    }

    private static List<int> ParseNumbers(string numbers)
        => numbers.Split(',').Select(int.Parse).ToList();
}

public class ParseResult
{
    public List<string> Rows { get; set; }
    public List<List<int>> Sizes { get; set; }

    public ParseResult(List<string> rows, List<List<int>> sizes)
    {
        Rows = rows;
        Sizes = sizes;
    }
}