using System;
namespace Sample.Stack
{
    public class StackDriver
    {
        Stack st = new Stack(5);
        StackList stList = new StackList();

        public StackDriver()
        {
            Initialize();
        }

        private void Initialize()
        {
            st.Push(10);
            st.Push(20);
            st.Push(30);
            st.Push(40);
            st.Push(50);
        }

        //private void Initialize

        public void DoOperation()
        {
            while (!st.IsEmpty())
                Console.WriteLine(st.Pop());
        }
    }
}
