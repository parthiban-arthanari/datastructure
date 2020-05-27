using System;
namespace Sample.DayChallenge
{
    public class BackSpaceStrCompare
    {
        public static BackSpaceStrCompare Instance = new BackSpaceStrCompare();
        string S;
        string T;

        private void Read()
        {
            S = "abc##g#d";
            T = "ae#f#d";

            //S = "ab##";
            //T = "c#d#";

            //S = "y#fo##f";
            //T = "y#fx#o##f";
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Whether Give String Are Equal {0}", Compare2(S, T).ToString());
        }

        private bool Compare(string S1, string T1)
        {
            int length = S1.Length > T1.Length ? S1.Length : T1.Length;
            int S_end = -1;
            int T_end = -1;
            bool isEqual = false;
            int MismatchedIndex = -1;
            char[] S = S1.ToCharArray();
            char[] T = T1.ToCharArray();

            for (int i = 0; i < length; i++)
            {
                if (S.Length > i)
                {
                    if (S_end >= 0 && S[i] == '#')
                    {
                        S_end--;
                    }
                    else
                    {
                        S_end++;
                        S[S_end] = S[i];
                    }
                }
                if (T.Length > i)
                {
                    if (T_end >= 0 && T[i] == '#')
                    {
                        T_end--;
                    }
                    else
                    {
                        T_end++;
                        T[T_end] = T[i];
                    }
                }
                if (S_end == T_end && S_end >= 0)
                {
                    if (S[S_end] == T[T_end])
                    {
                        if (MismatchedIndex == -1)
                        {
                            isEqual = true;
                        }
                        else if (MismatchedIndex == S_end)
                        {
                            isEqual = true;
                            MismatchedIndex = -1;
                        }
                    }
                    else if (MismatchedIndex == -1)
                    {
                        MismatchedIndex = S_end;
                    }

                }
                else
                    isEqual = false;
            }

            return isEqual && S_end == T_end;
        }

        private bool Compare2(string S, string T)
        {
            int i = S.Length - 1, j = T.Length - 1;
            int skipS = 0, skipT = 0;

            while (i >= 0 || j >= 0)
            { // While there may be chars in build(S) or build (T)
                while (i >= 0)
                { // Find position of next possible char in build(S)
                    if (S[i] == '#') { skipS++; i--; }
                    else if (skipS > 0) { skipS--; i--; }
                    else break;
                }
                while (j >= 0)
                { // Find position of next possible char in build(T)
                    if (T[j] == '#') { skipT++; j--; }
                    else if (skipT > 0) { skipT--; j--; }
                    else break;
                }
                // If two actual characters are different
                if (i >= 0 && j >= 0 && S[i] != T[j])
                    return false;
                // If expecting to compare char vs nothing
                if ((i >= 0) != (j >= 0))
                    return false;
                i--; j--;
            }
            return true;
        }
    }
}
 