using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class InserDeleteRandom
    {
        public static InserDeleteRandom Instance = new InserDeleteRandom();

        Dictionary<int, int> map;
        List<int> list;

        Random random;

        public void Do()
        {
            Insert(3);
            Insert(3);
            int temp = GetRandom();
            temp = GetRandom();
            Insert(1);
            Remove(3);
            temp = GetRandom();
            temp = GetRandom();
            Insert(0);
            Remove(0);
        }

        public InserDeleteRandom()
        {
            map = new Dictionary<int, int>();
            random = new Random();
            list = new List<int>();
        }

        public bool Insert(int val) 
        {
            if(map.ContainsKey(val))
                return false;
            
            map.Add(val, list.Count);
            list.Add(val);
            return true;
        }
    
        public bool Remove(int val) 
        {
            if(!map.ContainsKey(val))
                return false;
            
            int lastElement = list[list.Count -1];
            int index = map[val];
            list[index] = lastElement;
            map[lastElement] = index;

            list.RemoveAt(list.Count -1);
            map.Remove(val);
            
            return true;
        }
    
        public int GetRandom() 
        {
            int r = random.Next(0, list.Count-1);
            return list[r];
        }

    }
}