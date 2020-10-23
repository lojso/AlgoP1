using AlgorithmsDataStructures;

namespace AlgoP1
{
    public static class Task6Ad1
    {
        private static Deque<char> d;

        public static bool IsPalindrome(string word)
        {
            d = StringToDeque(word);
            int i = 0;
            while (d.Size() > 0)
            {
                if (word[i] != d.RemoveTail())
                    return false;
                i++;
            }

            return true;
        }

        private static Deque<char> StringToDeque(string word)
        {
            var result = new Deque<char>();
            for (int i = 0; i < word.Length; i++)
            {
                result.AddTail(word[i]);
            }
            return result;
        }
    }
}