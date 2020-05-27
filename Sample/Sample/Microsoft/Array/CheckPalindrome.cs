using System;
using System.Text;

namespace Sample.Microsoft.Array
{
    public class CheckPalindrome
    {
        public static CheckPalindrome Instance = new CheckPalindrome();
        string _s;

        private void Read()
        {
            _s = "A man, a plan, a canal: Panama";

        }

        public void Do()
        {
            Read();
            Console.WriteLine("Is Palindrome : {0}", IsPalindrome(_s).ToString());
        }

        private bool IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while(start < end)
            {
                int s_c = s[start];
                int e_c = s[end];

                if(!IsAccepted(s_c))
                {
                    start++;
                    continue;
                }
                
                if(!IsAccepted(e_c))
                {
                    end--;
                    continue;
                }

                if(!IsAlphaNumneric(s_c,e_c))
                    return false;

                start++;
                end--;
            }

            return true;
        }

        private bool IsAccepted(int val)
        {
            return IsAlpha(val) || (val >= 48 && val <= 57);
        }

        private bool IsAlphaNumneric(int val1, int val2)
        {
            if(IsAlpha(val1) && IsAlpha(val2))
            {
                if(val1 > val2)
                    return val1 - val2 == 32;
                else
                    return val2 -  val1 == 32 || val1 == val2;
            }

            return val1  == val2;
        }

        private bool IsAlpha(int val)
        {
            return (val >= 65 && val <= 90) || (val >= 97 && val <= 122);
        }
            
    }
}