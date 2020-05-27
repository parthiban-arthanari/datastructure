using System;
namespace Sample.Stack
{
    public class ExpressionEva
    {
        Stack st;
        int[] arr = { 1, 2, 3, 1,2,3};

        public ExpressionEva()
        {
            Initialize();
        }

        private void Initialize()
        {
            st = new Stack(10);
        }

        public void DoOperation()
        {
            if (CheckBalance())
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }

        private bool CheckBalance()
        { 
            if ( arr.Length % 2 != 0 || arr.Length == 0)
                return false;
            else
            {
                for(int i=0; i<arr.Length; i++)
                {
                    if (!st.IsEmpty())
                    {
                        int val = st.Peek();

                        if (val == arr[i])
                        {
                            st.Pop();
                        }
                    }
                    else
                        st.Push(arr[i]);
                }

                return st.IsEmpty();
            }
        }
    }
}
