using Task5;

namespace AlgoP1
{
    public static class Task5Ad2<T>
    {
        public static Queue<T> RotateQueue(Queue<T> q, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var val = q.Dequeue();
                q.Enqueue(val);
            }

            return q;
        }
    }
}