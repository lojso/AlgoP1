using Task6;

namespace AlgoP1
{
    public static class Task6Ad1
    {
        private static Deque<char> d;

        public static bool IsPalindrome(string word)
        {
            d = StringToDeque(word);
            while (d.Size() > 1)
            {
                if (d.RemoveFront() != d.RemoveTail())
                    return false;
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