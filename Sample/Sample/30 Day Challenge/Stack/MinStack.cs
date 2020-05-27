using System.Collections.Generic;
using System.Linq;

namespace Sample.DayChallenge
{
    public class MinStack
    {
        public static MinStack Instance = new MinStack();
        private Stack<int> _stack;
        private Stack<int> _minStack;

        public MinStack()
        {
            _stack = new Stack<int>();
            _minStack = new Stack<int>();
        }

        public void Do()
        {
            string[] operations = new string[] { "MinStack", "push", "push", "getMin", "getMin", "push", "getMin", "getMin", "top", "getMin", "pop", "push", "push", "getMin", "push", "pop", "top", "getMin", "pop" };
            int[] values = new int[] { 0, -10, 14, 0, 0, -20, 0, 0, 0, 0, 0, 10, -7, 0, -7, 0, 0, 0, 0 };
            string output = "[";

            for(int i =0; i< operations.Length; i++)
            { 
            //    string expected = "[null,null,null,-10,-10,null,-20,-20,-20,-20,null,null,null,-10,null,null,-7,-10,null]";
                string opr = operations[i] + "-" + values[i];

                switch (operations[i])
                {
                    case "push":
                        Push(values[i]);
                        output = output + "null,";
                        break;
                    case "pop":
                        Pop();
                        output = output + "null,";
                        break;
                    case "top":
                        output = output + Top().ToString() + ",";
                        break;
                    case "getMin":
                        output = output + GetMin().ToString() + ",";
                        break;
                    default:
                        output = output + "null";
                        break;
                }
            }
            
        }

        public void Push(int x)
        {
            _stack.Push(x);

            if(_minStack.Any())
            {
                int min = _minStack.Peek();
                if (min > x)
                   _minStack.Push(x);
                 else
                    _minStack.Push(min);
            }
            else
                _minStack.Push(x);

        }

        public void Pop()
        {
            if(_stack.Any())
                _stack.Pop();       
            if (_minStack.Any())
                _minStack.Pop();
        }

        public int Top()
        {
            if (_stack.Any())
                return _stack.Peek();
            return -1;
            
        }

        public int GetMin()
        {
            if(_minStack.Any())
                return _minStack.Peek();
            return -1;
        }
    }
}
