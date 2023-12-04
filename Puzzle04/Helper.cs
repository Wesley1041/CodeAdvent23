namespace Puzzle04
{
    public static class Helper
    {
        public static List<string> SmartSplit(string item, string divider)
        {
            return item
                .Split(divider)
                .ToList()
                .TrimList();
        }

        public static List<string> SmartSplit(string item, char divider)
        {
            return item
                .Split(divider)
                .ToList()
                .TrimList();
        }

        private static List<string> TrimList(this List<string> list)
        {
            return list.Where(x => !string.IsNullOrEmpty(x)).ToList();
        }
    }
}
