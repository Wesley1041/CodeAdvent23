namespace CodeAdvent23
{
    public class Elf
    {
        public List<int> Items { get; set; }

        public Elf(List<int> items)
        {
            Items = items;
        }

        public int GetCalories()
        {
            var calories = 0;

            foreach (var item in Items)
            {
                calories += item;
            }

            return calories;
        }
    }
}
