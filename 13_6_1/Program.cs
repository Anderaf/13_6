using System.Diagnostics;

namespace _13_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("text.txt");

            char[] separators = { ',','.','!','?',':','\'','\"','(',')','<','>',';','\n', '–', '«', '»', ' ','0','1','2','3','4','5','6','7','8','9' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Stopwatch stopwatch= new Stopwatch();

            long listTime = 0;
            long linkedListTime = 0;
            for (int i = 0; i < 1000; i++)
            {
                List<string> wordsList = new List<string>(100);
                stopwatch.Restart();
                foreach (string word in words)
                {
                    wordsList.Add(word);
                }               
                listTime += stopwatch.ElapsedMilliseconds;
                
                LinkedList<string> wordsLinkedlist = new LinkedList<string>();
                stopwatch.Restart();
                foreach (string word in words)
                {
                    wordsLinkedlist.AddLast(word);
                }
                linkedListTime += stopwatch.ElapsedMilliseconds;
            }

            Console.WriteLine("List: " + listTime / 1000f + " мс");
            Console.WriteLine("LinkedList: " + linkedListTime / 1000f + " мс");
        }
    }
}