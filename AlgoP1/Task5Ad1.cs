using Task6;

namespace AlgoP1
{
    public class Task5Ad1
    {
        public class Queue<T>
        {
            private Stack<T> _pushStack;
            private Stack<T> _popStack;

            private bool _isNowPush = true;

            public Queue()
            {
                _pushStack = new Stack<T>();
                _popStack = new Stack<T>();
            }

            public void Enqueue(T item)
            {
                _pushStack.Push(item);
            }

            public T Dequeue()
            {
                if (_popStack.Size() == 0)
                    FillPopStack();
                return _popStack.Pop();
            }

            private void FillPopStack()
            {
                while (_pushStack.Size() != 0)
                {
                    _popStack.Push(_pushStack.Pop());
                }
            }

            public int Size()
            {
                if (_isNowPush)
                    return _pushStack.Size();
                return _popStack.Size();
            }
        }
    }
}