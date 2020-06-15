using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class TowersOfHanoi
    {
        public static TowersOfHanoi Instance = new TowersOfHanoi();

        int n;
        Tuple<string, Stack<int>> source;
        Tuple<string, Stack<int>> destination;
        Tuple<string, Stack<int>> auxiliary;
        int disk;

        private void Read()
        {
            n = 5;

            source = new Tuple<string, Stack<int>>("A", new Stack<int>());
            destination = new Tuple<string, Stack<int>>("B", new Stack<int>());
            auxiliary = new Tuple<string, Stack<int>>("C", new Stack<int>());

            for(int i=n; i>0; i--)
                source.Item2.Push(i);
        }

        public void Do()
        {
            Read();
            DoMove(n, source, destination, auxiliary);
        }

        private void DoMove(int n, Tuple<string, Stack<int>> s, Tuple<string, Stack<int>> d, Tuple<string, Stack<int>> a)
        {
            string sou = s.Item1;
            string des = d.Item1;
            string aux = a.Item1;
            
            if(n==1)
            {
                disk = s.Item2.Pop();
                d.Item2.Push(disk);
                Console.WriteLine("Move disk {0} from {1} to {2}", disk, s.Item1, d.Item1);
                
                return;
            }

            DoMove(n-1, s,a,d);
            disk = s.Item2.Pop();
            d.Item2.Push(disk);
            Console.WriteLine("Move disk {0} from {1} to {2}", disk, s.Item1, d.Item1);
            DoMove(n-1, a, d, s );
        }
    }
}