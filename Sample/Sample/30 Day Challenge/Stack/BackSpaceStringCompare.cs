using System;
using System.Collections.Generic;

namespace Sample.DayChallenge
{
    public class BackSpaceStringCompare
    {
        public static BackSpaceStringCompare Instance = new BackSpaceStringCompare();
        string str1, str2;
        private void Read()
        {
            str1 = "ab#c";
            str2 = "ad#c";
        }

        public void Do()
        {
            Read();
            Compare(str1, str2);
        }

        private bool Compare(string str1, string str2)
        {
            return ProcessString(str1).Equals(ProcessString(str2));
        }

        private string ProcessString(string str)
        {
            Stack<char> stack = new Stack<char>(str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '#')
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                    stack.Push(str[i]);
            }          
            return new string(stack.ToArray());

        }

        private bool ComapreWithoutExtraSpace(string S, string T)
        {
            return true;
        }
    }
}
