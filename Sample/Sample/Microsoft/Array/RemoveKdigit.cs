using System;
using System.Text;

namespace  Sample.Microsoft.Array
{
    public class RemoveKdigit
    {
        public static RemoveKdigit Instance = new RemoveKdigit();
        string s;
        int len;

        private void Read()
        {
            s = "1432219";
            len = 3;
        }

        public void Do()
        {
            Read();
            Remove(s, len);

        }

        private string Remove(string num, int k)
        {
            if (num.Length == k)
                return "0";

            StringBuilder sb = new StringBuilder(num);

            for (int j = 0; j < k; j++) 
            {
                int i = 0;
                while (i < sb.Length - 1 && sb[i] <= sb[i + 1]) 
                {
                    i++;
                }
                sb.Remove(i, 1);
            }

            while (sb.Length > 1 && sb[0] == '0')
                sb.Remove(0, 1);

            if (sb.Length == 0) 
            {
                return "0";
            }

            return sb.ToString();

        }
    }
}