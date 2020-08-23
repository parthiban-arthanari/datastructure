using System;
using System.Collections.Generic;

namespace Sample.Bit
{
    public class BitSum
    {
        public static BitSum Instance = new BitSum();

        string s1;
        string s2;

        private void Read()
        {
            s1= "11";
            s2 = "1";
        }

        public void Do()
        {
            Read();
            var val = Sum(s1,s2);

        }

        private string Sum(string a, string b)
        {
            int l = a.Length > b.Length ? a.Length : b.Length;
            List<char> c = new List<char>();
            int i = l-1;
            int carry = 0;

            while(i >= 0)
            {
                int count = l-i;
                int n = b.Length >= count ? b.Length - count : -1;
                int n1 = n != -1 ? int.Parse(b[n].ToString()) : 0;
                n = a.Length >= count ? a.Length - count : -1;
                int n2 = n != -1 ? int.Parse(a[n].ToString()) : 0;

                int sum = n1 + n2 + carry;
                carry =  sum / 2;
                c.Add(char.Parse((sum % 2).ToString()));
                i--;
            }

            if(carry > 0)
                c.Add(char.Parse(carry.ToString()));
            c.Reverse();

            return new string(c.ToArray());
        }
    }
}