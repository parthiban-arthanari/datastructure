using System;
using System.Text;

namespace Sample.Array
{
    public class ReverseStringByWord
    {
        public static ReverseStringByWord Instance = new ReverseStringByWord();

        string _str;

        private void Read()
        {
            _str = "the sky is blue";
        }

        public void Do()
        {
            Read();
            var val = Reverse(_str);
        }

        public string Reverse(string s)
        {
            StringBuilder builder = new StringBuilder();
            int start = s.Length -1;
            int count =0;

            for(int i=start; i>=-1; i--)
            {
                if(i >=0 && !char.IsWhiteSpace(s[i]))
                {
                    count++;
                    start = i;
                }
                else if(count > 0)
                {
                    if(builder.Length > 0)
                        builder.Append(" ");
                    builder.Append(s.Substring(start, count));
                    count =0;
                }
            }

            return builder.ToString();
        }
    }
}