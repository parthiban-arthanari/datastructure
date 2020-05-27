using System;
using System.Collections.Generic;

namespace  Sample.Stack
{
    public class StockSpanner
    {
        public static StockSpanner Instance = new StockSpanner();

        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();

        public void Do()
        {
            int[] price = new int[]{100,80,60,70,60,75,85};

            foreach(var p in price)
            {
                int value = Next(p);
                Console.WriteLine(value);
            }
        }

        private int Next(int price)
        {
            int span = 1;

            while(stack.Count > 0)
            {
                Tuple<int, int> top = stack.Peek();

                if(top.Item1 <= price)
                {
                    stack.Pop();
                    span = span + top.Item2;
                }
                else
                {
                    break;
                }
            }

            stack.Push(new Tuple<int, int>(price, span));

            return span;
        }
    }
}