using Puzzle12;

var parseResult = Parser.ParseInput();
var rows = parseResult.Rows;
var sizes = parseResult.Sizes;
var sum = 0;

for (var i = 0; i < rows.Count; i++)
    sum += GetCombinations("", rows[i], i);

Console.WriteLine($"Sum: {sum}");

// Functions
int GetCombinations(string given, string remaining, int index)
{
    // Test combination
    if (string.IsNullOrEmpty(remaining))
        return CheckValidity(given, index) ? 1 : 0;

    var next = remaining.First();
    if (next == '?')
        return GetCombinations(given + '#', remaining[1..], index) + GetCombinations(given + '.', remaining[1..], index);

    return GetCombinations(given + next, remaining[1..], index);
}

bool CheckValidity(string given, int index)
{
    var target = sizes[index];
    var brokenSprings = given.Split('.').Where(s => !string.IsNullOrEmpty(s)).ToList();
    return target.Count == brokenSprings.Count &&
        !target.Where((t, i) => brokenSprings[i].Length != t).Any();
}