using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class StringDecode
    {
        public static StringDecode Instance = new StringDecode();

        string s;
        int k;

        private void Read()
        {
            s = "a2b3c4d5e6f7g8h9";
            k = 10;
        }

        public void Do()
        {
            Read();
            var val = GetDecodeString(s, k);
        }

        private string GetDecodeString(string S, int K1)
        {
            long size = 0;
            long K = K1;
            int N = S.Length;
            int i =0;
            // Find size = length of decoded string
            for (i = 0; i < N && size < k; ++i) 
            {
                char c = S[i];
                if (Char.IsDigit(c))
                    size *= c - '0';
                else
                    size++;
            }
            i--;
            for (; i >= 0; --i) 
            {
                char c = S[i];
                K %= size;
                if (K == 0 && Char.IsLetter(c))
                    return c.ToString();

                if (Char.IsDigit(c))
                    size /= c - '0';
                else
                    size--;
            }

            throw null;
        }
    }
}