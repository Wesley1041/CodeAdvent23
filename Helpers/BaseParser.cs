namespace Helpers;

public static class BaseParser
{
    public static List<string> ParseLines()
    {
        var lines = new List<string>();
        while (true)
        {
            var line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) return lines;
            lines.Add(line);
        }
    }
}