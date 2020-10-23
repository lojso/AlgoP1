using AlgorithmsDataStructures;

namespace AlgoP1
{
    public class Task5Ad1
    {
        public class Queue<T>
        {
            private Stack<T> stack
            {
                get { return _isNowPush ? _pushStack : _popStack; }
            }

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
                if (!_isNowPush)
                    ChangeActiveStack();
                stack.Push(item);
            }

            public T Dequeue()
            {
                if (_isNowPush)
                    ChangeActiveStack();
                return stack.Pop();
            }
            private void ChangeActiveStack()
            {
                if (_isNowPush)
                {
                    while (stack.Size() > 0)
                    {
                        _popStack.Push(_pushStack.Pop());
                    }
                    _isNowPush = false;
                }
                else
                {
                    while (stack.Size() > 0)
                    {
                        _pushStack.Push(_popStack.Pop());
                    }
                    _isNowPush = true;
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