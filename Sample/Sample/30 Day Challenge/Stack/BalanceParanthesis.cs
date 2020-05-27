using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DayChallenge
{
    public class BalanceParanthesis
    {
        public static BalanceParanthesis Instance = new BalanceParanthesis();
        string s;
        bool ans = false;

        private void Read()
        {
            s = "(*)))*";
            //s = "((((()(()()()*()(((((*)()*(**(())))))(())()())(((())())())))))))(((((())*)))()))(()((*()*(*)))(*)()";
        }

        public void Do()
        {
            Read();
            Console.WriteLine("The given string is balanced:  {0}", checkValidString(s));
        }

        private string IsBalanced(string s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>()
            {
                {'(',')'}
            };
            char specialChar = '*';

            Stack<Tuple<char, int>> stack1 = new Stack<Tuple<char,int>>(s.Length);
            Stack<Tuple<char, int>> stack2 = new Stack<Tuple<char, int>>(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (current == specialChar)
                {
                    stack2.Push(new Tuple<char, int>(current, i));
                }
                else if (stack1.Count == 0)
                {
                    stack1.Push(new Tuple<char, int>(current, i));
                }
                else
                {
                    char top = stack1.Peek().Item1;
                    if (map.ContainsKey(top) && map[top] == current)
                        stack1.Pop();
                    else
                        stack1.Push(new Tuple<char, int>(current, i));

                }
            }

            while (stack1.Count > 0)
            {
                Tuple<char, int> top = stack1.Peek();
                if(map.ContainsKey(top.Item1))
                {
                    if (stack2.Count > 0)
                    {
                        Tuple<char, int> top1 = stack2.Peek();
                        if (top1.Item2 > top.Item2)
                        {
                            stack1.Pop();
                            stack2.Pop();
                        }
                        else
                            stack2.Pop();
                    }
                    else
                        return false.ToString();
                }
                else
                {
                    if (stack2.Count > 0)
                    {
                        Tuple<char, int> top1 = stack2.Peek();
                        if (top1.Item2 < top.Item2)
                        {
                            stack1.Pop();
                            stack2.Pop();
                        }
                        else
                            stack2.Pop();
                    }
                    else
                        return false.ToString();
                }
            }
            return true.ToString();
        }

        public bool checkValidString(String s)
        {
            solve(new StringBuilder(s), 0);
            return ans;
        }

        public void solve(StringBuilder sb, int i)
        {
            if (i == sb.Length)
            {
                bool temp = valid(sb);
                ans |= temp;
            }
            else if (sb[i] == '*')
            {
                string c = "() ";
                for (int j=0; j<c.Length; j++)
                {
                    sb[i] = c[j];
                    solve(sb, i + 1);
                    if (ans) return;
                }
                sb[i] = '*';
            }
            else
                solve(sb, i + 1);
        }

        public bool valid(StringBuilder sb)
        {
            int bal = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                char c = sb[i];
                if (c == '(') bal++;
                if (c == ')') bal--;
                if (bal < 0) break;
            }
            return bal == 0;
        }
    }
}
