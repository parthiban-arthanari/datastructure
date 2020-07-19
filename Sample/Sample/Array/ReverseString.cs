using System;

namespace Sample.Array
{
    public class ReverseString
    {
        public static ReverseString Instance = new ReverseString();

        char[] c;

        private void Read()
        {
            c = Utility.ConvertArray<char>("[h,e,l,l,o]");
        }

        public void Do()
        {
            Read();
            Reverse(c);
        }

        public void Reverse(char[] c)
        {
            int start = 0;
            int end = c.Length -1;

            while(start < end)
            {
                char temp = c[start];
                c[start] = c[end];
                c[end] = temp;
                start++;
                end--;
            }

        }

    }
}