namespace Task13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("text.txt");

            char[] separators = { ',', '.', '!', '?', ':', '\'', '\"', '(', ')', '<', '>', ';', '\n', '–', '«', '»', ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordsCountDictionary = new Dictionary<string, int>();
            foreach (string word in words) 
            {
                if (wordsCountDictionary.TryGetValue(word, out int value))
                {
                    wordsCountDictionary[word] = value + 1;
                }
                else
                {
                    wordsCountDictionary.Add(word, 1);
                }
            }

            var sorted = wordsCountDictionary.OrderByDescending(x => x.Value).ToArray();
            for (int i = 0; i < Math.Min(10, sorted.Length); i++)
            {
                Console.WriteLine($"{i + 1}) {sorted[i].Key} - {sorted[i].Value}");
            }
        }
    }
}