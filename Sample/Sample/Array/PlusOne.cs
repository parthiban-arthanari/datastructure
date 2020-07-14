using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class PlusOne
    {
        public static PlusOne Instance = new PlusOne();

        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,9]");
        }

        public void Do()
        {
            Read();
            int[] val = Find(arr);
        }
        private int[] Find(int[] digits)
        {
            LinkedList<int> list = new LinkedList<int>();
            int carry = 1;
            for(int i=digits.Length -1; i>=0; i--)
            {
                int val = (digits[i] + carry) % 10;
                carry = (digits[i] + carry) / 10;
                list.AddFirst(val);
            }
            if(carry > 0)
                list.AddFirst(carry);
            digits = new int[list.Count];
            list.CopyTo(digits, 0);

            return digits;
        }
    }
}