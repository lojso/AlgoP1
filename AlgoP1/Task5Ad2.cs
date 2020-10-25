using Task5;

namespace AlgoP1
{
    public static class Task5Ad2<T>
    {
        public static Queue<T> RotateQueueRight(Queue<T> q, int n)
        {
            n = n % q.Size();
            n = q.Size() - n;
            return RotateQueueLeft(q, n);
        }
        
        public static Queue<T> RotateQueueLeft(Queue<T> q, int n)
        {
            n = n % q.Size();
            for (int i = 0; i < n; i++)
            {
                var val = q.Dequeue();
                q.Enqueue(val);
            }

            return q;
        }
    }
}