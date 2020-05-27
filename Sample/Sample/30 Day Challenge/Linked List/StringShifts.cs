using System;
using System.Collections.Generic;
namespace Sample.DayChallenge
{
    public class StringShifts
    {
        string s;
        int[,] shift;
        public static StringShifts Instance = new StringShifts();

        private void Read()
        {
            //s = "abcdefg";
            shift = new int[,] { { 1, 1 }, { 1, 1 }, { 0, 2 }, { 1, 3 } };

            s = "ecfchzgoqdtay";
            shift = new int[,] { { 0, 6},{1,9},{ 0,6},{ 0,12},{ 0,7},{ 0,2},{ 0,12},{ 0,6},{ 0,8},{ 0,6},{ 0,7},{ 1,0},{0,12} };
        }

        public void Do()
        {
            Read();
            Console.WriteLine("String after shifting: {0}", StringShift(s, shift));

        }

        public string StringShift(string s, int[,] shift)
        {
            LinkedList<char> list = StringToList(s);
            int left = 0;
            int right = 0;

            for(int i =0; i< shift.GetLength(0); i++)
            {
                switch (shift[i,0])
                {
                    case 0:
                        left += shift[i, 1];
                        break;
                    case 1:
                        right += shift[i, 1];
                        break;
                }
            }

            //if (left > right)
            //    ShiftLeft(list, (left - right) % (2*s.Length));
            //else
            //    ShiftRight(list, (right - left) % (2 * s.Length));

            if (left > right)
                return ShiftLeft1(s, (left - right) % s.Length);
            else
                return ShiftRight1(s, (right - left) % s.Length);
        }

        private LinkedList<char> StringToList(string s)
        {
            LinkedList<char> list = new LinkedList<char>();

            for(int i=0; i<s.Length; i++)
            {
                if (i == 0)
                    list.AddFirst(s[i]);
                else
                    list.AddAfter(list.Last, s[i]);
            }

            return list;
        }

        private string ListToString(LinkedList<char> list)
        {
            char[] c = new char[list.Count];

            int i = 0;
            foreach(char node in list)
            {
                c[i] = node;
                i++;
            }

            return new string(c);
        }

        private void ShiftLeft(LinkedList<char> list, int pos)
        {
            while (pos > 0)
            {
                LinkedListNode<char> first = list.First;
                list.RemoveFirst();

                list.AddLast(first.Value);
                pos--;
            }
        }

        private string ShiftLeft1(string s, int pos)
        {
            string subString = s.Substring(0, pos);
            return s.Remove(0, pos) + subString;
        }

        private string ShiftRight1(string s, int pos)
        {
            string subString = s.Substring(s.Length - pos, pos);
            return subString + s.Remove(s.Length - pos, pos);
        }

        private void ShiftRight(LinkedList<char> list, int pos)
        {
           while (pos > 0)
            {
                LinkedListNode<char> last = list.Last;
                list.RemoveLast();

                list.AddFirst(last.Value);
                pos--;
            }
        }
    }
}
