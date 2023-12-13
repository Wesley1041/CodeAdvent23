namespace Puzzle11;

public class ParseResult
{
    public int[] EmptyColumns { get; set; }
    public int[] EmptyRows { get; set; }
    public bool[,] Grid { get; set; }

    public ParseResult(int[] emptyColumns, int[] emptyRows, bool[,] grid)
    {
        EmptyColumns = emptyColumns;
        EmptyRows = emptyRows;
        Grid = grid;
    }
}