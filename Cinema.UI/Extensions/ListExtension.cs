namespace Cinema.UI.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random RandomGenerator = new Random();

        public static List<T> GetRandomDistinctElements<T>(this List<T> sourceList, int count)
        {
            if (count >= sourceList.Count || count < 0)
            {
                // Return a copy of the entire list if count is equal to or greater than the list size.
                return sourceList.ToList();
            }

            List<T> resultList = new List<T>();
            HashSet<int> selectedIndices = new HashSet<int>();

            while (resultList.Count < count)
            {
                int randomIndex = RandomGenerator.Next(0, sourceList.Count);

                if (!selectedIndices.Contains(randomIndex))
                {
                    resultList.Add(sourceList[randomIndex]);
                    selectedIndices.Add(randomIndex);
                }
            }

            return resultList;
        }
    }
}
