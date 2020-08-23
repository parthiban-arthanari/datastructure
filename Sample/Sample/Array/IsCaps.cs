using System;

namespace Sample.Array
{
    public class IsCaps
    {
        public static IsCaps Instance = new IsCaps();

        string str;

        private void Read()
        {
            str = "Google";
        }

        public void Do()
        {

        }

        private bool IsCap(string word)
        {
            bool isCaps = false;
            for(int i=0; i< word.Length ; i++)
            {
                if(isCaps && !char.IsUpper(word[i]))
                    return false;
                
                if(!isCaps && i > 0 && char.IsUpper(word[i]))
                    return false;
                
                isCaps = char.IsUpper(word[i]);
            }

            return isCaps || !isCaps;
        }
    }
}